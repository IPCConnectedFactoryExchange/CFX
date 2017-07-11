using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.WorkCenterServices;

namespace CFXTestApplication
{
    class CFXMessageGenerator
    {
        public CFXMessageGenerator()
        {
        }

        public string EndpointId
        {
            get;
            set;
        }
        public CFXEnvelope CreateEnvelope(Type messageType)
        {
            CFXEnvelope env = new CFXEnvelope(messageType);
            env.EndpointID = EndpointId;
            return env;
        }

        public List<object> CreateReflowWIPMessages()
        {
            List<object> results = new List<object>();

            string unitId = CreateNewBarcode();
            
            CFXEnvelope env = CreateEnvelope(typeof(UnitStarted));
            (env.MessageBody as UnitStarted).UnitIdentifier = unitId;
            results.Add(env);

            Guid transId = (env.MessageBody as UnitStarted).UnitTransactionID;
            DateTime start = env.TimeStamp;

            env = CreateEnvelope(typeof(UnitStageCompleted));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(.6);
            (env.MessageBody as UnitStageCompleted).UnitIdentifier = unitId;
            (env.MessageBody as UnitStageCompleted).UnitTransactionID = transId;
            (env.MessageBody as UnitStageCompleted).StageName = "PREHEAT";

            env = CreateEnvelope(typeof(UnitStageCompleted));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(1.2);
            (env.MessageBody as UnitStageCompleted).UnitIdentifier = unitId;
            (env.MessageBody as UnitStageCompleted).UnitTransactionID = transId;
            (env.MessageBody as UnitStageCompleted).StageName = "SOAK";

            env = CreateEnvelope(typeof(UnitStageCompleted));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(1.8);
            (env.MessageBody as UnitStageCompleted).UnitIdentifier = unitId;
            (env.MessageBody as UnitStageCompleted).UnitTransactionID = transId;
            (env.MessageBody as UnitStageCompleted).StageName = "REFLOW";

            env = CreateEnvelope(typeof(UnitStageCompleted));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(2.4);
            (env.MessageBody as UnitStageCompleted).UnitIdentifier = unitId;
            (env.MessageBody as UnitStageCompleted).UnitTransactionID = transId;
            (env.MessageBody as UnitStageCompleted).StageName = "COOL";
                        
            env = CreateEnvelope(typeof(UnitCompleted));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(2.4);
            (env.MessageBody as UnitCompleted).UnitIdentifier = unitId;
            (env.MessageBody as UnitCompleted).UnitTransactionID = transId;

            env = CreateEnvelope(typeof(UnitProcessed));
            results.Add(env);
            env.TimeStamp = start.AddMinutes(3);
            (env.MessageBody as UnitProcessed).UnitIdentifier = unitId;
            (env.MessageBody as UnitProcessed).UnitTransactionID = transId;
            (env.MessageBody as UnitProcessed).ProcessStartTime = start;
            (env.MessageBody as UnitProcessed).ProcessCompletedTime = start.AddMinutes(2.4);
            ReflowProcessData rData = new ReflowProcessData();
            (env.MessageBody as UnitProcessed).ProcessData = "<< Machine Specific Process Data Goes Here >>";
            //(env.MessageBody as UnitProcessed).ProcessData = rData;

            ZoneReflowProcessData zData;
            Measurement m;

            zData = new ZoneReflowProcessData();
            rData.ZoneProcessData.Add(zData);
            zData.ZoneName = "PREHEA1T";
            zData.ZoneType = ZoneType.PreHeat;
            m = new Measurement("ZONETEMPERATURE");
            zData.AmbientConditions.Add(m);
            m.SampleTime = start.AddMinutes(0.6);
            m.Units = "C";
            m.MeasuredValue = 150.45;
            m = new Measurement("T1");
            zData.UnitExperience.Add(m);
            m.Units = "C";
            m.SampleTime = start.AddMinutes(0.3);
            m.MeasuredValue = 80.56;
            m = new Measurement("T1");
            zData.UnitExperience.Add(m);
            m.Units = "C";
            m.SampleTime = start.AddMinutes(0.6);
            m.MeasuredValue = 135.88;
            
            zData = new ZoneReflowProcessData();
            rData.ZoneProcessData.Add(zData);
            zData.ZoneName = "SOAK1";
            zData.ZoneType = ZoneType.Soak;
            m = new Measurement("ZONETEMPERATURE");
            zData.AmbientConditions.Add(m);
            m.Units = "C";
            m.MeasuredValue = 149.32;
            m = new Measurement("T1");
            zData.UnitExperience.Add(m);
            m.Units = "C";
            m.SampleTime = start.AddMinutes(0.9);
            m.MeasuredValue = 120.44;
            m = new Measurement("T1");
            zData.UnitExperience.Add(m);
            m.Units = "C";
            m.SampleTime = start.AddMinutes(1.2);
            m.MeasuredValue = 148.92;

            zData = new ZoneReflowProcessData();
            rData.ZoneProcessData.Add(zData);
            zData.ZoneName = "REFLOW1";
            zData.ZoneType = ZoneType.Reflow;
            m = new Measurement("ZONETEMPERATURE");
            zData.AmbientConditions.Add(m);
            m.Units = "C";
            m.MeasuredValue = 232.21;

            zData = new ZoneReflowProcessData();
            rData.ZoneProcessData.Add(zData);
            zData.ZoneName = "COOLING1";
            zData.ZoneType = ZoneType.Cool;
            m = new Measurement("ZONETEMPERATURE");
            zData.AmbientConditions.Add(m);
            m.Units = "C";
            m.MeasuredValue = 110.23;

            return results;
        }


        private int nextId = 1;
        public string CreateNewBarcode()
        {
            return string.Format("UNIT{0,8:D8}", nextId++);
        }

    }
}

