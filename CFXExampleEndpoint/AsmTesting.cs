using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.Production;
using CFX.Production.TestAndInspection;
using CFX.Structures;
using CFX.Structures.PCBInspection;

namespace CFXExampleEndpoint
{
    class AsmTesting
    {
        public AsmTesting()
        {

        }

        public List<CFXEnvelope> Messages
        {
            get;
            set;
        }

        public void CreateGetRecipe()
        {
            Messages = new List<CFXEnvelope>();

            GetRecipeResponse rsp = new GetRecipeResponse()
            {
                Result = new RequestResult() { Message = "OK", Result = StatusResult.Success },
                Recipe = new PCBInspectionRecipe()
                {
                    Name = "AOIRecipe1",
                    Revision = "1",
                    Panel = new Panel()
                    {
                        Name = "Panel23434",
                    }
                }
            };
            Messages.Add(new CFXEnvelope(rsp));

            SetClipboard();
        }


        public void CreateUnitsInspected()
        {
            //Messages = new List<CFXEnvelope>();
            
            Guid tid = Guid.NewGuid();
            Stage stg = new Stage() { StageName = "INSP1", StageSequence = 1, StageType = StageType.Work };
            
            WorkStarted ws = new WorkStarted()
            {
                TransactionID = tid,
                
                Units = new UnitPosition[]
                {
                    new UnitPosition() { PositionName = "1", PositionNumber = 1, UnitIdentifier = "PANEL_SERIALNUM_1234567"},
                    new UnitPosition() { PositionName = "2", PositionNumber = 2, UnitIdentifier = "PANEL_SERIALNUM_1234567"},
                }.ToList(),
            };
            Messages.Add(new CFXEnvelope(ws));

            WorkStageStarted wss = new WorkStageStarted()
            {
                TransactionID = tid,
                Stage = stg,
            };
            Messages.Add(new CFXEnvelope(wss));

            ActivitiesExecuted ae = new ActivitiesExecuted()
            {
                TransactionID = tid,
                Stage = stg,
                Activities = new Activity[]
                {
                    new UnitAlignmentActivity()
                    {
                        ActivityName = "PFID1",
                        Comments = "Panel Fiducial 1 Presence and Alignment Check",
                        ActivityInstanceId = Guid.NewGuid(),
                        ActivityState = ActivityState.Completed,
                    },
                    new UnitAlignmentActivity()
                    {
                        ActivityName = "PFID2",
                        Comments = "Panel Fiducial 2 Presence and Alignment Check",
                        ActivityInstanceId = Guid.NewGuid(),
                        ActivityState = ActivityState.Completed,
                    },
                }.ToList()
            };
            Messages.Add(new CFXEnvelope(ae));

            List<Defect> defects = new Defect[]
            {
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2"},
                    DefectCode = "DisplacementError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "DisplacementX",
                            MeasuredValue = new NumericValue() {Value = -39.547279586959121, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "DisplacementY",
                            MeasuredValue = new NumericValue() {Value = 11.42419208741012, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "Rotation",
                            MeasuredValue = new NumericValue() {Value = 0.040963607505005939, ValueUnits = "deg" }
                        }
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2"},
                    DefectCode = "PolarityError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "LineWidthDifference",
                            MeasuredValue = new NumericValue() {Value = 614 }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "MatchValue",
                            MeasuredValue = new NumericValue() {Value = 484 }
                        },
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2"},
                    DefectCode = "HeightError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "Height",
                            MeasuredValue = new NumericValue() {Value = -39.547279586959121, ValueUnits = "%" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "TiltX",
                            MeasuredValue = new NumericValue() {Value = 11.42419208741012, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "TiltY",
                            MeasuredValue = new NumericValue() {Value = 0.040963607505005939, ValueUnits = "µm" }
                        }
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2"},
                    DefectCode = "ReferenceError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "Volume",
                            MeasuredValue = new NumericValue() {Value = 104.95069720322059, ValueUnits = "%" }
                        },
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2"},
                    DefectCode = "PresenceError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "TiltX",
                            MeasuredValue = new NumericValue() {Value = -13, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "TiltY",
                            MeasuredValue = new NumericValue() {Value = 9, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "ValidArea",
                            MeasuredValue = new NumericValue() {Value = - 79, ValueUnits = "%" }
                        },
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2.7"},
                    DefectCode = "PinAngularError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "GapWidthLiftedLead",
                            MeasuredValue = new NumericValue() {Value = 0}
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "GapWidthBridge",
                            MeasuredValue = new NumericValue() {Value = 16}
                        },
                        }.ToList(),
                },
                new Defect()
                {
                    ComponentOfInterest = new ComponentDesignator() {ReferenceDesignator = "IC2.7"},
                    DefectCode = "PinDisplacementError",
                    RelatedMeasurements = new Measurement []
                    {
                        new NumericMeasurement ()
                        {
                            MeasurementName = "DisplacementX",
                            MeasuredValue = new NumericValue() {Value = -17, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "DisplacementY",
                            MeasuredValue = new NumericValue() {Value = -13, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "PinLength",
                            MeasuredValue = new NumericValue() {Value = 874, ValueUnits = "µm" }
                        },
                        new NumericMeasurement ()
                        {
                            MeasurementName = "PinWidth",
                            MeasuredValue = new NumericValue() {Value = 183, ValueUnits = "µm" }
                        }
                        }.ToList(),
                },
            }.ToList();
                                                                                                                
            UnitsRepaired ui = new UnitsInspected()
            {
                TransactionId = Guid.NewGuid(),
                InspectionMethod = InspectionMethod.AOI,
                InspectedUnits = new InspectedUnit[]
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL_SERIALNUM_1234567",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Failed,
                        Inspections = new Inspection[]
                        {
                            new Inspection()
                            {
                                InspectionName = "IC2",
                                Result = TestResult.Failed,
                                DefectsFound = defects,
                            },
                            new Inspection()
                            {
                                InspectionName = "U20",
                                Result = TestResult.Failed,
                                DefectsFound = Clone<List<Defect>>(defects)
                            },
                        }.ToList(),
                    }
                }.ToList(),
            };

            ui.InspectedUnits[0].Inspections[1].DefectsFound.ForEach(d => d.ComponentOfInterest.ReferenceDesignator = d.ComponentOfInterest.ReferenceDesignator.Replace("IC2", "U20"));
            ui.InspectedUnits.Add(Clone<InspectedUnit>(ui.InspectedUnits[0]));
            ui.InspectedUnits[1].UnitPositionNumber = 2;
            Messages.Add(new CFXEnvelope(ui));

            WorkStageCompleted wsc = new WorkStageCompleted() { Result = WorkResult.Failed, Stage = stg, TransactionID = tid };
            Messages.Add(new CFXEnvelope(wsc));

            WorkCompleted wc = new WorkCompleted() { Result = WorkResult.Failed, TransactionID = tid };
            Messages.Add(new CFXEnvelope(wc));

            SetClipboard();
        }

        private T Clone<T>(T source)
        {
            string json = CFX.Utilities.CFXJsonSerializer.SerializeObject(source);
            return CFX.Utilities.CFXJsonSerializer.DeserializeObject<T>(json);
        }

        private void SetClipboard()
        {
            string result = "";

            CFX.Utilities.CFXJsonSerializer.JsonSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
            
            Messages.ForEach(m => result += (m.ToJson(true) + "\r\n"));
            System.Windows.Forms.Clipboard.SetText(result);
        }
    }
}
