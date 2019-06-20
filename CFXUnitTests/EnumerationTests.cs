using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFX;
using CFX.Utilities;
using CFX.Structures;
using CFX.ResourcePerformance;
using System.IO;

namespace CFXUnitTests
{
    //[TestClass]
    //public class EnumerationTests
    //{
    //    private const string testFile = @"d:\stuff\CFX\TestData.json";


    //    [TestMethod]
    //    public void WriteEnum()
    //    {
    //        CFXMessage msg = new StationStateChanged()
    //        {
    //            NewState = ResourceState.ENG,
    //            OldState = ResourceState.SBY,
    //            OldStateDuration = TimeSpan.FromSeconds(20)
    //        };

    //        CFXEnvelope env = new CFXEnvelope(msg);
    //        WriteToFile(env);
    //    }

    //    [TestMethod]
    //    public void ReadEnum()
    //    {
    //        CFXEnvelope env = ReadFromFile();

    //        StationStateChanged msg = env.GetMessage<StationStateChanged>();
    //        int i = (int)msg.NewState;
    //        int j = (int)msg.OldState;
    //        Assert.IsTrue(env != null);
    //    }

    //    private void WriteToFile(CFXEnvelope env)
    //    {
    //        using (StreamWriter sw = new StreamWriter(testFile, false, System.Text.Encoding.UTF8))
    //        {
    //            sw.Write(env.ToJson(true));
    //        }
    //    }

    //    private CFXEnvelope ReadFromFile()
    //    {
    //        using (StreamReader sr = new StreamReader(testFile, System.Text.Encoding.UTF8))
    //        {
    //            return CFXEnvelope.FromJson(sr.ReadToEnd());
    //        }
    //    }
    //}
}
