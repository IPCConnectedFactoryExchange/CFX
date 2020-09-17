using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CFX.Utilities;

namespace CFX.Transport
{
    internal class DurableQueue
    {
        public DurableQueue(string name)
            : base()
        {
            dataName = System.IO.Path.GetTempPath();
            string safeName = name.Replace('\\', '-');
            safeName = safeName.Replace('/', '-');
            dataName += (@"\" + safeName + ".cache");
            Initialize();
        }

        ~DurableQueue()
        {
            Close();
        }

        private string dataName = "";
        private BinaryWriter dataWriter = null;
        private BinaryReader dataReader = null;
        private uint fileSignature { get { return 0xfe982422; } }
        private uint fileVersion { get { return pvtFileVersion; } set { pvtFileVersion = value; } }
        private uint pvtFileVersion = 1;
        private object syncObject = new object();
        private List<CFXEnvelope> queue = new List<CFXEnvelope>();

        private void Initialize()
        {
            // Create and/open cache file and load existing cache into memory
            try
            {
                // Clear in-memory queue
                queue.Clear();

                // Create and Open Cache Index and Data files
                FileStream dataFile = new FileStream(dataName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                dataReader = new BinaryReader(dataFile, System.Text.Encoding.UTF8);
                dataWriter = new BinaryWriter(dataFile, System.Text.Encoding.UTF8);
                ReadData();
                OpenWriter();
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }
        }

        public bool IsEmpty
        {
            get
            {
                lock (syncObject)
                {
                    return (queue.Count < 1);
                }
            }
        }

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        private bool ReadData()
        {
            bool result = false;

            lock (syncObject)
            {
                try
                {
                    queue.Clear();
                    if (dataReader == null) return false;
                    if (dataReader.BaseStream.Length < 1) return true;
                    dataReader.BaseStream.Seek(0, SeekOrigin.Begin);

                    // Read the File Signature
                    uint sig = dataReader.ReadUInt32();
                    if (sig == this.fileSignature)
                    {
                        // Read the Version Tag
                        fileVersion = dataReader.ReadUInt32();

                        // Read the Cache Size
                        int cacheSize = dataReader.ReadInt32();

                        for (int i = 0; i < cacheSize; i++)
                        {
                            CFXEnvelope rec = CFXEnvelope.ReadRecord(dataReader);
                            if (rec != null && !rec.Transmitted)
                            {
                                if (!rec.Transmitted) queue.Add(rec);
                            }
                        }

                        result = true;
                    }
                }
                catch (Exception e)
                {
                    AppLog.Error(e);
                }
            }

            if (!result) queue.Clear();
            return result;
        }

        private bool OpenWriter()
        {
            try
            {
                if (dataWriter == null) return false;

                // Validate File
                if (dataWriter.BaseStream.Length > 0)
                {
                    dataWriter.BaseStream.Seek(0, SeekOrigin.End);
                }
                else
                {
                    // Write Signature
                    dataWriter.Write(this.fileSignature);

                    // Write File Version
                    dataWriter.Write(this.fileVersion);

                    // Write the Cache Size
                    dataWriter.Write((int)0);

                    dataWriter.Flush();
                }

                return true;
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }

            return false;
        }

        public void Close()
        {
            if (dataWriter != null) dataWriter.Dispose();
            if (dataReader != null) dataReader.Dispose();
            dataWriter = null;
            dataReader = null;
        }

        public bool Enqueue(CFXEnvelope obj)
        {
            bool result = false;
            lock (syncObject)
            {
                try
                {
                    obj.Transmitted = false;
                    if (dataWriter != null)
                    {
                        obj.WriteRecord(dataWriter);

                        dataWriter.BaseStream.Seek(8, SeekOrigin.Begin);
                        int cacheSize = dataReader.ReadInt32();
                        int curCount = cacheSize + 1;
                        dataWriter.BaseStream.Seek(8, SeekOrigin.Begin);
                        dataWriter.Write(curCount);
                        dataWriter.BaseStream.Seek(0, SeekOrigin.End);
                        dataWriter.Flush();
                    }

                    queue.Add(obj);
                    result = true;
                }
                catch (Exception e)
                {
                    AppLog.Error(e);
                }
            }
            return result;
        }

        public CFXEnvelope Peek()
        {
            CFXEnvelope result = null;

            try
            {
                if (queue.Count > 0) result = queue[0];
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }

            return result;
        }

        public CFXEnvelope [] PeekMany(int maxCount)
        {
            CFXEnvelope [] result = null;

            try
            {
                if (queue.Count > 0)
                {
                    result = queue.Take(queue.Count < maxCount ? queue.Count : maxCount).ToArray();
                }
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }

            return result;
        }

        public CFXEnvelope [] Dequeue(int count = 1)
        {
            CFXEnvelope [] result = null;

            lock (syncObject)
            {
                try
                {
                    result = PeekMany(count);
                    if (result != null)
                    {
                        queue.RemoveRange(0, result.Length);
                        if (queue.Count < 1)
                        {
                            InternalClear();
                        }
                        else
                        {
                            foreach (CFXEnvelope env in result) env.SetRecordTransmitted(dataWriter);
                        }
                    }
                }
                catch (Exception e)
                {
                    AppLog.Error(e);
                }
            }

            return result;
        }

        public void Clear()
        {
            lock (syncObject)
            {
                InternalClear();
            }
        }

        private void InternalClear()
        {
            try
            {
                queue.Clear();
                if (dataWriter != null)
                {
                    dataWriter.BaseStream.SetLength(0);
                    dataWriter.Flush();
                    OpenWriter();
                }
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }
        }
    }
}
