using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.Structures;
using CFX.Structures.SMTPlacement;
using CFX.Structures.SolderPastePrinting;
using CFX.Structures.SolderApplication;
using CFX.Structures.THTInsertion;
using CFX.Structures.SolderPasteInspection;
using CFX.Structures.PCBInspection;
using CFX.Structures.SolderReflow;
using CFX.Production;
using CFX.Production.Assembly;
using CFX.Production.Application;
using CFX.Production.TestAndInspection;
using CFX.Production.ReworkAndRepair;
using CFX.InformationSystem.UnitValidation;
using CFX.InformationSystem.WorkOrderManagement;
using CFX.InformationSystem.ProductionScheduling;
using CFX.Sensor.Identification;
using CFX.Materials;
using CFX.Materials.Storage;
using CFX.Materials.Management;
using CFX.Materials.Management.MSDManagement;
using CFX.Materials.Transport;
using CFX.ResourcePerformance;
using CFX.ResourcePerformance.SMTPlacement;
using CFX.ResourcePerformance.SolderPastePrinting;
using CFX.ResourcePerformance.THTInsertion;
using CFX.Production.Application.Solder;
using CFX.Production.Processing;
using CFX.Structures.Coating;
using CFX.Structures.ReflowProfiling;
using CFX.Production.Hermes;
using CFX.Structures.Maintenance;

namespace CFXExampleEndpoint
{
    public class CFXExampleGenerator
    {
        public string GenerateAll()
        {
            InitializeMaterials();

            string result = "";
            result += GenerateInformationSystem();
            result += GenerateRoot();
            result += GenerateResourcePerformance();
            result += GenerateProduction();
            result += GenerateAssembly();
            result += GenerateTest();
            result += GenerateMaterials();
            return result;
        }

        private MaterialPackageDetail m1, m2, m3, m4, m5, m6, m7;
        private MaterialCarrier c1, c2, c3;
        private Tool t1, t2, t3;

        Operator op1;

        public string GenerateAssembly()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new MaterialsInstalled()
            {
                TransactionId = Guid.NewGuid(),
                InstalledMaterials = new List<InstalledMaterial>(new InstalledMaterial[]
                {
                    new InstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Material = m1.ToMaterialPackage(),
                        CarrierLocation = new MaterialCarrierLocation()
                        {
                            LocationIdentifier = "UID384234893",
                            LocationName = "SLOT45",
                            CarrierInformation = c2
                        },
                        QuantityInstalled = 3,
                        InstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })

                    },
                    new InstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Material = m1.ToMaterialPackage(),
                        CarrierLocation = new MaterialCarrierLocation()
                        {
                            LocationIdentifier = "UID384234893",
                            LocationName = "SLOT45",
                            CarrierInformation = c2
                        },
                        QuantityInstalled = 3,
                        InstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsUninstalled()
            {
                TransactionId = Guid.NewGuid(),
                UninstalledMaterials = new List<UninstalledMaterial>(new UninstalledMaterial[]
                {
                    new UninstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Material = m1.ToMaterialPackage(),
                        QuantityUninstalled = 3,
                        UninstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })

                    },
                    new UninstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Material = m1.ToMaterialPackage(),
                        QuantityUninstalled = 3,
                        UninstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsApplied()
            {
                TransactionId = Guid.NewGuid(),
                AppliedMaterials = new List<InstalledMaterial>(new InstalledMaterial[]
                {
                    new InstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Material = m1.ToMaterialPackage(),
                        QuantityInstalled = 3.57,
                    },
                    new InstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Material = m1.ToMaterialPackage(),
                        QuantityInstalled = 3.45,
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsUnapplied()
            {
                TransactionId = Guid.NewGuid(),
                UnappliedMaterials = new List<UninstalledMaterial>(new UninstalledMaterial[]
                {
                    new UninstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Material = m1.ToMaterialPackage(),
                        QuantityUninstalled = 3.55,
                    },
                    new UninstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Material = m1.ToMaterialPackage(),
                        QuantityUninstalled = 3.55,
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new ToolsUsed()
            {
                TransactionId = Guid.NewGuid(),
                UsedTools = new List<ToolUsed>(new ToolUsed[]
                {
                    new ToolUsed()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Tool = t1,
                        UsageCycles = 3,
                        InstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })

                    },
                    new ToolUsed()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Tool = t2,
                        UsageCycles = 3,
                        InstalledComponents = new List<InstalledComponent>(new InstalledComponent []
                        {
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R1"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R2"
                            },
                            new InstalledComponent(setDateTime:true)
                            {
                                ReferenceDesignator = "R3"
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            (msg as ToolsUsed).UsedTools[0].InstalledComponents.Clear();
            (msg as ToolsUsed).UsedTools[1].InstalledComponents.Clear();
            (msg as ToolsUsed).UsedTools[0].Tool = t3;
            (msg as ToolsUsed).UsedTools[1].Tool = t3;
            AppendMessage(msg, ref result);

            msg = new UnitsPersonalized()
            {
                TransactionId = Guid.NewGuid(),
                PersonalizedUnits = new List<PersonalizedUnit>(new PersonalizedUnit[]
                {
                    new PersonalizedUnit()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 1,
                        Characteristics = new List<Characteristic>(new Characteristic []
                        {
                            new Characteristic()
                            {
                                Name = "MAC Address",
                                Value = "C0-15-B9-2D-0F-3B"
                            }
                        })
                    },
                    new PersonalizedUnit()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPositionNumber = 2,
                        Characteristics = new List<Characteristic>(new Characteristic []
                        {
                            new Characteristic()
                            {
                                Name = "MAC Address",
                                Value = "C0-15-B9-2D-0F-3C"
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            SelectiveSolderData ssd1 = new SelectiveSolderData()
            {
                Process_Status = "Completed",
                RecipeName = "Panasonic 2up",
                Nitrogen_Pressure = 54,
                Air_Pressure = 62,
                Cycle_Count = 671261,
                Cycle_Time = new TimeSpan(0, 0, 1, 44, 200),
                Nitrogen_Purity = 15,
                Nitrogen_Flow = 39,
                Fiducial_Enabled = true
            };

            SelectiveSolderProcessData sspd1 = new SelectiveSolderProcessData()
            {
                Process_Status = "Completed",
                RecipeName = "Panasonic 2up",
                Nitrogen_Pressure = 54,
                Air_Pressure = 62,
                Cycle_Count = 671261,
                Cycle_Time = new TimeSpan(0, 0, 1, 44, 200),
                Nitrogen_Purity = 15,
                Nitrogen_Flow = 39,
                Fiducial_Enabled = true
            };

            ZoneData z1 = new ZoneData()
            {
                StageSequence = 1,
                ProcessTime = new TimeSpan(0, 0, 15, 0),
                Bottle1_Pressure = 7.0,
                Bottle2_Pressure = 7.0,
                Flux_Volume = 210,
                Top_Preheater_Power = 50,
                Top_Preheater_Soak = 10,
                Top_Preheater_Temp = 109,
                Top_Preheater_Time = new TimeSpan(0, 0, 37),
                Fid_XCorrection = 0.15,
                Fid_YCorrection = 0.2
            };

            ZoneData z2 = new ZoneData()
            {
                StageSequence = 2,
                ProcessTime = new TimeSpan(0, 0, 37),
                Top_Preheater_Power = 50,
                Top_Preheater_Soak = 10,
                Top_Preheater_Temp = 109,
                Top_Preheater_Time = new TimeSpan(0, 0, 37),
                Bot_Preheater_Power = 50,
                Bot_Preheater_Soak = 10,
                Bot_Preheater_Temp = 108,
                Bot_Preheater_Time = new TimeSpan(0, 0, 37),
            };

            ZoneData z3 = new ZoneData()
            {
                StageSequence = 3,
                ProcessTime = new TimeSpan(0, 0, 37),
                Top_Preheater_Power = 50,
                Top_Preheater_Soak = 10,
                Top_Preheater_Temp = 109,
                Top_Preheater_Time = new TimeSpan(0, 0, 37),
                Bot_Preheater_Power = 50,
                Bot_Preheater_Soak = 10,
                Bot_Preheater_Temp = 108,
                Bot_Preheater_Time = new TimeSpan(0, 0, 37),
                Bath_Temp = 305,
                Bath_Wave_Enabled = true,
                Bath_Wave_Hgt = 0.1,
                Solder_Quantity_Used = 5,
                Fid_XCorrection = 0.15,
                Fid_YCorrection = 0.2
            };

            msg = new PCBSelectiveSoldered()
            {
                TransactionId = Guid.NewGuid(),
                HeaderData = ssd1,
                SolderedPCBs = new List<SelectiveSolderedPCB>(new SelectiveSolderedPCB[] {
                    new SelectiveSolderedPCB()
                    {
                        UnitIdentifier = "PANEL4325435",
                        UnitPositionNumber = 1,
                        ZoneData = new List<ZoneData>(new ZoneData [] {z1, z2, z3 })
                    },
                    new SelectiveSolderedPCB()
                    {
                        UnitIdentifier = "PANEL4325435",
                        UnitPositionNumber = 2,
                        ZoneData = new List<ZoneData>(new ZoneData [] {z1, z2, z3 })
                    }
                })
            };


            AppendMessage(msg, ref result);

            msg = new UnitsProcessed()
            {
                TransactionId = Guid.NewGuid(),
                CommonProcessData = sspd1,
                OverallResult = ProcessingResult.Succeeded,
                UnitProcessData = new List<ProcessedUnit>()
                {
                    new ProcessedUnit()
                    {
                        UnitIdentifier = "PANEL4325435",
                        UnitPositionNumber = 1,
                        UnitProcessData = new SelectiveSolderPCBProcessData()
                        {
                            ZoneData = new List<ZoneData>()  {z1, z2, z3 }
                        }
                    },
                    new ProcessedUnit()
                    {
                        UnitIdentifier = "PANEL4325435",
                        UnitPositionNumber = 2,
                        UnitProcessData = new SelectiveSolderPCBProcessData()
                        {
                            ZoneData = new List<ZoneData>()  {z1, z2, z3 }
                        }
                    }
                }
            };

            AppendMessage(msg, ref result);



            return result;
        }

        public string GenerateTest()
        {
            string result = "";

            Operator op1 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "Joseph",
                LastName = "Smith",
                LoginName = "joseph.smith@abcdrepairs.com",
                OperatorIdentifier = "BADGE489499"
            };

            CFXMessage msg = new UnitsInspected()
            {
                TransactionId = Guid.NewGuid(),
                Inspector = op1,
                InspectionMethod = InspectionMethod.AOI,
                InspectedUnits = new List<InspectedUnit>(new InspectedUnit[]
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Passed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_R21",
                                Result = TestResult.Passed,
                            },
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_R22",
                                Result = TestResult.Passed
                            }
                        })
                    },
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 2,
                        OverallResult = TestResult.Failed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_R21",
                                Result = TestResult.Passed
                            },
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_R22",
                                Result = TestResult.Failed,
                                DefectsFound = new List<Defect>(new Defect []
                                {
                                    new Defect()
                                    {
                                        DefectCode = "ISFSLD112",
                                        DefectCategory = "Solder Problems",
                                        Description = "Insuffiecient Solder on R22, Lead 1",
                                        ComponentOfInterest = new ComponentDesignator()
                                        {
                                            ReferenceDesignator = "R22.1",
                                            PartNumber = "11123-8897"
                                        },
                                        DefectImages = new List<Image>(new Image []
                                        {
                                            new Image () {ImageData = new byte[] {0xac,0x54,0x56,0x77,0xd8,0x99} }
                                        })

                                    },
                                    new Defect()
                                    {
                                        DefectCode = "TMBSTN211",
                                        DefectCategory = "Solder Problems",
                                        Description = "Tombston on R22",
                                        ComponentOfInterest = new ComponentDesignator()
                                        {
                                            ReferenceDesignator = "R22",
                                            PartNumber = "11123-8897"
                                        },
                                        DefectImages = new List<Image>(new Image []
                                        {
                                            new Image () {ImageData = new byte[] {0x5d,0x28,0xe3,0x87,0xc8,0xb9} }
                                        })
                                    }
                                })
                            },
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "COSMETIC_INSPECTION",
                                Result = TestResult.Failed,
                                DefectsFound = new List<Defect>(new Defect []
                                {
                                    new Defect()
                                    {
                                        DefectCode = "SCR23443",
                                        DefectCategory = "Cosmetic Problems",
                                        Description = "Scratch Detected on PCB substrate",
                                        RegionOfInterest = new Region()
                                        {
                                            StartPointX = 2.3,
                                            StartPointY = 4.0,
                                            RegionSegments = new List<Segment>(new Segment []
                                            {
                                                new Segment()
                                                {
                                                    X = 5.6, Y = 4.0
                                                },
                                                new Segment()
                                                {
                                                    X = 5.6, Y = 1.6
                                                },
                                                new Segment()
                                                {
                                                    X = 2.3, Y = 1.6
                                                },
                                                new Segment()
                                                {
                                                    X = 2.3, Y = 4.0
                                                },
                                            })
                                        }
                                    }
                                })
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            /// PCB Paste Inspection Example
            msg = new UnitsInspected()
            {
                TransactionId = Guid.NewGuid(),
                Inspector = op1,
                InspectionMethod = InspectionMethod.SPI,
                InspectedUnits = new List<InspectedUnit>(new InspectedUnit[]
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Passed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_PASTE_DEPOSITIONS",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new SolderPasteMeasurement()
                                    {
                                        MeasurementName = "R1.1",
                                        Result = TestResult.Passed,
                                        CRDs = "R1.1",
                                        DX = 0.02,
                                        DY = 0.03,
                                        X = 5.62,
                                        EX = 5.60,
                                        Y = 8.29,
                                        EY = 8.30,
                                        Z = 5.01,
                                        EZ = 5.00,
                                        Vol = 5.11,
                                        EVol = 5.10,
                                    },
                                    new SolderPasteMeasurement()
                                    {
                                        MeasurementName = "R1.2",
                                        Result = TestResult.Passed,
                                        CRDs = "R1.1",
                                        DX = 0.02,
                                        DY = 0.03,
                                        X = 5.62,
                                        EX = 5.60,
                                        Y = 8.29,
                                        EY = 8.30,
                                        Z = 5.01,
                                        EZ = 5.00,
                                        Vol = 5.11,
                                        EVol = 5.10,
                                    },
                                })
                            },
                        })
                    },
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 2,
                        OverallResult = TestResult.Failed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_PASTE_DEPOSITIONS",
                                Result = TestResult.Passed,
                               Measurements = new List<Measurement>(new Measurement []
                                {
                                    new SolderPasteMeasurement()
                                    {
                                        MeasurementName = "R1.1",
                                        Result = TestResult.Passed,
                                        CRDs = "R1.1",
                                        DX = 0.02,
                                        DY = 0.03,
                                        X = 5.62,
                                        EX = 5.60,
                                        Y = 8.29,
                                        EY = 8.30,
                                        Z = 5.01,
                                        EZ = 5.00,
                                        Vol = 5.11,
                                        EVol = 5.10,
                                    },
                                    new SolderPasteMeasurement()
                                    {
                                        MeasurementName = "R1.2",
                                        Result = TestResult.Passed,
                                        CRDs = "R1.1",
                                        DX = 0.02,
                                        DY = 0.03,
                                        X = 5.62,
                                        EX = 5.60,
                                        Y = 8.29,
                                        EY = 8.30,
                                        Z = 5.01,
                                        EZ = 5.00,
                                        Vol = 5.11,
                                        EVol = 5.10,
                                    },
                                })
                            },
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            UnitsRepaired ur = new UnitsRepaired()
            {
                TransactionId = Guid.NewGuid(),
                RepairOperator = op1,
                RepairedUnits = new List<RepairedUnit>()
                {
                    new RepairedUnit()
                    {
                        UnitIdentifier = "FFSHkkskamJDHS",
                        UnitPositionNumber = 1,
                        Repairs = new List<Repair>()
                        {
                            new Repair()
                            {
                                RelatedDefectIdentifiers = new List<string>()
                                {
                                    Guid.NewGuid().ToString(),
                                },
                                Comments = "Repaired cold solder joint at U34, Pin 5",
                                RepairName=  "Joint Repair",
                                Result = RepairResult.RepairSuccessful,
                                RepairStartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(40)),
                                RepairEndTime = DateTime.Now,
                                ComponentOfInterest = new ComponentDesignator()
                                {
                                    ReferenceDesignator = "U34.5",
                                    PartNumber = "SN74HCS30DR"
                                }
                            },
                            new Repair()
                            {
                                RelatedDefectIdentifiers = new List<string>()
                                {
                                    Guid.NewGuid().ToString(),
                                },
                                Comments = "Repaired solder bridge at U24, Pins 4-5",
                                RepairName=  "Joint Repair",
                                Result = RepairResult.RepairSuccessful,
                                RepairStartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(40)),
                                RepairEndTime = DateTime.Now,
                                ComponentOfInterest = new ComponentDesignator()
                                {
                                    ReferenceDesignator = "U24.4-5",
                                    PartNumber = "SN74HCS50DR"
                                }
                            },
                        }
                    }
                }
            };

            AppendMessage(ur, ref result);

            UnitsInspected ui = msg as UnitsInspected;
            
            for (int i = 0; i < ui.InspectedUnits.Count; i++)
            {
                for (int j = 0; j < 5000; ++j)
                {
                    if (ui.InspectedUnits[i].Inspections.Count > 1)
                    {
                        Inspection insp = ui.InspectedUnits[i].Inspections[0];
                        ui.InspectedUnits[i].Inspections = new List<Inspection>();
                        ui.InspectedUnits[i].Inspections.Add(insp);
                    }
                    ui.InspectedUnits[i].Inspections[0].Measurements.Clear();
                    ui.InspectedUnits[i].Inspections[0].Measurements.Add(
                        new SolderPasteMeasurement()
                        {
                            MeasurementName = "R1.1",
                            Result = TestResult.Passed,
                            CRDs = "R1.1",
                            DX = 0.02,
                            DY = 0.03,
                            X = 5.62,
                            EX = 5.60,
                            Y = 8.29,
                            EY = 8.30,
                            Z = 5.01,
                            EZ = 5.00,
                            Vol = 5.11,
                            EVol = 5.10,
                        });
                }
            }


            /// PCB Inspection Example With Component Offset Measurements
            msg = new UnitsInspected()
            {
                TransactionId = Guid.NewGuid(),
                Inspector = op1,
                InspectionMethod = InspectionMethod.SPI,
                InspectedUnits = new List<InspectedUnit>(new InspectedUnit[]
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Passed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_COMPONENT_OFFSETS",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R1",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R2",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R3",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R4",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                })
                            },
                        })
                    },
                    new InspectedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 2,
                        OverallResult = TestResult.Failed,
                        Inspections = new List<Inspection>(new Inspection []
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                InspectionName = "INSPECT_COMPONENT_OFFSETS",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R1",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R2",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R3",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                    new OffsetMeasurement()
                                    {
                                        CRDs = "R4",
                                        Result = TestResult.Passed,
                                        DX = 0.02, DY = 0.01, DZ = 0.01, RXY = 0.01, RZX = 0.15, RZY = 0.15,
                                    },
                                })
                            },
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsTested()
            {
                TransactionId = Guid.NewGuid(),
                Tester = op1,
                TestMethod = TestMethod.Automated,
                TestedUnits = new List<TestedUnit>(new TestedUnit[]
                {
                    new TestedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Passed,
                        Tests = new List<Test>(new Test []
                        {
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "RESISTANCE_CHECK_R21",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new NumericMeasurement()
                                    {
                                        UniqueIdentifier = Guid.NewGuid().ToString(),
                                        MeasurementName = "RESISTANCE_MEASUREMENT_R21",
                                        CRDs = "R21",
                                        Result = TestResult.Passed,
                                        MeasuredValue = new NumericValue()
                                        {
                                            ExpectedValue = 28.2,
                                            ExpectedValueUnits = "kOhm",
                                            MaximumAcceptableValue = 28.4,
                                            MinimumAcceptableValue = 28.0,
                                            Value = 28300,
                                            ValueUnits = "Ohm",
                                        }
                                    }
                                })
                            },
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "RESISTANCE_CHECK_R22",
                                Result = TestResult.Failed,
                                SymptomsFound = new List<Symptom>(new Symptom []
                                {
                                    new Symptom ()
                                    {
                                        UniqueIdentifier = Guid.NewGuid().ToString(),
                                        SymptomCode = "RESFAIL2",
                                        SymptomCategory = "Electrical Tests",
                                        Description = "Resistance Value Out of Tolerance",
                                        ComponentsOfInterest = new List<ComponentDesignator>(new ComponentDesignator []
                                        {
                                            new ComponentDesignator()
                                            {
                                                ReferenceDesignator = "R22.1",
                                                PartNumber = "41234-8897"
                                            },
                                            new ComponentDesignator()
                                            {
                                                ReferenceDesignator = "R22.2",
                                                PartNumber = "41234-8897"
                                            }
                                        }),
                                        RelatedMeasurements = new List<Measurement>(new Measurement []
                                        {
                                            new NumericMeasurement()
                                            {
                                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                                MeasurementName = "RESISTANCE_MEASUREMENT_R22",
                                                CRDs = "R22",
                                                MeasuredValue = new NumericValue()
                                                {
                                                    ExpectedValue = 28.2,
                                                    ExpectedValueUnits = "kOhm",
                                                    MaximumAcceptableValue = 28.4,
                                                    MinimumAcceptableValue = 28.0,
                                                    Value = 28.52,
                                                    ValueUnits = "kOhm"
                                                },
                                                Result = TestResult.Passed,
                                            }
                                        })
                                    }
                                }),
                            }
                        })
                    },
                    new TestedUnit()
                    {
                        UnitIdentifier = "PANEL34543535",
                        UnitPositionNumber = 2,
                        OverallResult = TestResult.Passed,
                        Tests = new List<Test>(new Test []
                        {
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "RESISTANCE_CHECK_R21",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new NumericMeasurement()
                                    {
                                        UniqueIdentifier = Guid.NewGuid().ToString(),
                                        MeasurementName = "RESISTANCE_MEASUREMENT_R21",
                                        CRDs = "R21",
                                        MeasuredValue = new NumericValue()
                                        {
                                            ExpectedValue = 28.2,
                                            ExpectedValueUnits = "kOhm",
                                            MaximumAcceptableValue = 28.4,
                                            MinimumAcceptableValue = 28.0,
                                            Value = 28300,
                                            ValueUnits = "Ohm",
                                        },
                                        Result = TestResult.Passed,
                                    }
                                })
                            },
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "RESISTANCE_CHECK_R22",
                                Result = TestResult.Passed,
                                Measurements = new List<Measurement>(new Measurement []
                                {
                                    new NumericMeasurement()
                                    {
                                        UniqueIdentifier = Guid.NewGuid().ToString(),
                                        MeasurementName = "RESISTANCE_MEASUREMENT_R22",
                                        CRDs = "R22",
                                        MeasuredValue = new NumericValue()
                                        {
                                            ExpectedValue = 28.2,
                                            ExpectedValueUnits = "kOhm",
                                            MaximumAcceptableValue = 28.4,
                                            MinimumAcceptableValue = 28.0,
                                            Value = 28300,
                                            ValueUnits = "Ohm",
                                        },
                                        Result = TestResult.Passed,
                                    }
                                })
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsTested()
            {
                TransactionId = Guid.NewGuid(),
                Tester = op1,
                TestMethod = TestMethod.Automated,
                TestedUnits = new List<TestedUnit>(new TestedUnit[]
                {
                    new TestedUnit()
                    {
                        UnitIdentifier = "UNIT123456789",
                        UnitPositionNumber = 1,
                        OverallResult = TestResult.Passed,
                        Tests = new List<Test>(new Test []
                        {
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "HOT_TEST",
                                Result = TestResult.Passed,
                                TestStartTime = DateTime.Now - TimeSpan.FromSeconds(32),
                                TestEndTime = DateTime.Now,
                                TestConditions = new List<EnvironmentalCondition>(new EnvironmentalCondition []
                                {
                                    new Temperature() { MeanValue = 45.2, MaxValue = 45.8, MinValue = 44.9 },
                                    new Humidity() { MeanValue = 85.5, MaxValue = 85.7, MinValue = 85.4 },
                                })
                            },
                            new Test()
                            {
                                UniqueIdentifier = Guid.NewGuid().ToString(),
                                TestName = "COLD_TEST",
                                Result = TestResult.Passed,
                                TestStartTime = DateTime.Now - TimeSpan.FromSeconds(32),
                                TestEndTime = DateTime.Now,
                                TestConditions = new List<EnvironmentalCondition>(new EnvironmentalCondition []
                                {
                                    new Temperature() { MeanValue = -6.5, MaxValue = -6.4, MinValue = -6.7 },
                                    new Humidity() { MeanValue = 22.5, MaxValue = 22.7, MinValue = 22.4 },
                                })
                            }
                        })
                    }
                })
            };
            AppendMessage(msg, ref result);

            return result;
        }

        public string GenerateRoot()
        {
            string result = "";

            CFXMessage msg = new WhoIsThereRequest()
            {
                SupportedTopicQueryType = SupportedTopicQueryType.All,
                SupportedTopics = new List<SupportedTopic>(new SupportedTopic[]
                {
                    new SupportedTopic()
                    {
                        TopicName = "CFX.Production",
                        TopicSupportType = TopicSupportType.Publisher,
                    },
                    new SupportedTopic()
                    {
                        TopicName = "CFX.Production.Appplication",
                        TopicSupportType = TopicSupportType.Publisher,
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new WhoIsThereResponse()
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123",
                RequestNetworkUri = "amqp://host33/",
                RequestTargetAddress = "/queue/SN23123"
            };
            AppendMessage(msg, ref result);

            msg = new AreYouThereRequest()
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123",
            };
            AppendMessage(msg, ref result);

            msg = new AreYouThereResponse()
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123",
                RequestNetworkUri = "amqp://host33/",
                RequestTargetAddress = "/queue/SN23123"
            };
            AppendMessage(msg, ref result);

            msg = new GetEndpointInformationRequest
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123"
            };
            AppendMessage(msg, ref result);

            msg = new GetEndpointInformationResponse
            {
                EndpointInformation = new Endpoint()
                {
                    CFXHandle = "SMTPlus.Model_21232.SN23123",
                    RequestNetworkUri = "amqp://host55:5688/",
                    RequestTargetAddress = "/queue/SN23123",
                    UniqueIdentifier = "UID1111111111111111",
                    FriendlyName = "SMD Printer 23123",
                    Vendor = "SMT Plus",
                    ModelNumber = "Model_11111",
                    SerialNumber = "SNSN23123",
                    NumberOfLanes = 1,
                    Stages = new List<StageInformation>(new StageInformation []
                    {
                        new StageInformation() {Stage = new Stage() {StageName = "INBOUND BUFFER", StageSequence = 1, StageType = StageType.Buffer} },
                        new StageInformation() {Stage = new Stage() {StageName = "WORK STAGE 1", StageSequence = 2, StageType = StageType.Work} },
                        new StageInformation() {Stage = new Stage() {StageName = "OUTBOUND BUFFER", StageSequence = 3, StageType = StageType.Buffer} },
                    }),
                    HermesInformation = new HermesInformation()
                    {
                        Enabled = true,
                        Version = "1.0"
                    },
                    OperatingRequirements = new OperatingRequirements()
                    {
                        MinimumHumidity = 0.0,
                        MaximumHumidity = 0.8,
                        MinimumTemperature = -1.0,
                        MaximumTemperature = 40.0
                    },
                    SupportedTopics = new List<SupportedTopic>(new SupportedTopic[]
                    {
                        new SupportedTopic()
                        {
                            TopicName = "CFX.Production",
                            TopicSupportType = TopicSupportType.PublisherConsumer
                        },
                        new SupportedTopic()
                        {
                            TopicName = "CFX.Production.Application",
                            TopicSupportType = TopicSupportType.Publisher
                        },
                        new SupportedTopic()
                        {
                            TopicName = "CFX.ResourcePerformance",
                            TopicSupportType = TopicSupportType.Publisher
                        },
                    })
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetEndpointInformationResponse
            {
                EndpointInformation = new SMTPlacementEndpoint()
                {
                    CFXHandle = "SMTPlus.Model_21232.SN23123",
                    RequestNetworkUri = "amqp://host33:5688/",
                    RequestTargetAddress = "/queue/SN23123",
                    UniqueIdentifier = "UID564545645645656564",
                    FriendlyName = "SMD Placer 23123",
                    Vendor = "SMT Plus",
                    ModelNumber = "Model_21232",
                    SerialNumber = "SN23123",
                    NumberOfLanes = 1,
                    HermesInformation = new HermesInformation()
                    {
                        Enabled = true,
                        Version = "1.0"
                    },
                    OperatingRequirements = new OperatingRequirements()
                    {
                        MinimumHumidity = 0.0,
                        MaximumHumidity = 0.8,
                        MinimumTemperature = -1.0,
                        MaximumTemperature = 40.0
                    },
                    SupportedTopics = new List<SupportedTopic>(new SupportedTopic[]
                    {
                        new SupportedTopic()
                        {
                            TopicName = "CFX.Production",
                            TopicSupportType = TopicSupportType.PublisherConsumer
                        },
                        new SupportedTopic()
                        {
                            TopicName = "CFX.Production.Assembly",
                            TopicSupportType = TopicSupportType.Publisher
                        },
                        new SupportedTopic()
                        {
                            TopicName = "CFX.ResourcePerformance",
                            TopicSupportType = TopicSupportType.Publisher
                        },
                    }),
                    SupportedPCBDimensions = new DimensionalConstraints()
                    {
                        MinimumWidth = 10.0,
                        MaximumWidth = 1000.0,
                        MinimumLength = 10.0,
                        MaximumLength = 1000.0,
                        MinimumHeight = 0.0,
                        MaximumHeight = 50.0,
                        MinimumThickness = 0.5,
                        MaximumThickness = 10.0,
                        MinimumWeight = 0.0,
                        MaximumWeight = 1000.0
                    },
                    NominalPlacementCPH = 10000,
                    NominalUnitsPerHour = 120,
                    PlacementConstraints = new SMTPlacementConstraints()
                    {
                    },
                    Stages = new List<StageInformation>(new SMTStageInformation[]
                    {
                        new SMTStageInformation()
                        {
                            Stage = new Stage()
                            {
                                StageSequence = 1,
                                StageName = "BUFFERSTAGE1",
                                StageType = StageType.Buffer
                            },
                            NumberOfFeederStations = 0
                        },
                        new SMTStageInformation()
                        {
                            Stage = new Stage()
                            {
                                StageSequence = 2,
                                StageName = "WORKSTAGE1",
                                StageType = StageType.Work
                            },
                            NumberOfFeederStations = 100
                        },
                        new SMTStageInformation()
                        {
                            Stage = new Stage()
                            {
                                StageSequence = 3,
                                StageName = "WORKSTAGE2",
                                StageType = StageType.Work
                            },
                            NumberOfFeederStations = 100
                        }
                    }),
                    Lanes = new List<SMTLaneInformation>(new SMTLaneInformation[]
                    {
                        new SMTLaneInformation()
                        {
                            LaneName = "LANE1",
                        },
                        new SMTLaneInformation()
                        {
                            LaneName = "LANE2",
                        }
                    }),
                    Heads = new List<SMTHeadInformation>(new SMTHeadInformation[]
                    {
                        new SMTHeadInformation()
                        {
                            Head = new Head()
                            {
                                HeadId = "HD212343",
                                HeadName = "HEAD1",
                                HeadSequence = 1                                
                            },
                            PlacementAccuracy = 0.001,
                            NumberOfNozzleLocations = 6,
                            SMTHeadType = SMTHeadType.Pulsar
                        },
                        new SMTHeadInformation()
                        {
                            Head = new Head()
                            {
                                HeadId = "HD212344",
                                HeadName = "HEAD2",
                                HeadSequence = 2
                            },
                            PlacementAccuracy = 0.001,
                            NumberOfNozzleLocations = 6,
                            SMTHeadType = SMTHeadType.Pulsar
                        }
                    })
                }
            };
            AppendMessage(msg, ref result);

            msg = new EndpointConnected()
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123",
                RequestNetworkUri = "amqp://host33/",
                RequestTargetAddress = "/queue/SN23123"
            };
            AppendMessage(msg, ref result);

            CFXEnvelope env = new CFXEnvelope(msg);
            result += "CFXEnvelope\r\n===========\r\n";
            result += env.ToJson();
            result += "\r\n\r\n";

            msg = new EndpointShuttingDown()
            {
                CFXHandle = "SMTPlus.Model_21232.SN23123",
            };
            AppendMessage(msg, ref result);

            return result;
        }

        public string GenerateResourcePerformance()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new CalibrationPerformed()
            {
                Calibration = new Calibration()
                {
                    CalibrationCode = "FID1",
                    CalibrationType = CalibrationType.UnitPosition,
                    Comments = "Position Check.  Fiducial FID1.",
                    Status = OperationStatus.Ok,
                    CalibrationTime = null
                }
            };
            AppendMessage(msg, ref result);

            Fault flt = new Fault()
            {
                Cause = FaultCause.MechanicalFailure,
                Severity = FaultSeverity.Error,
                FaultCode = "ERROR 3943480",
            };

            msg = new StationStateChanged()
            {
                OldState = ResourceState.SBY_NoProduct,
                OldStateDuration = TimeSpan.FromSeconds(85),
                NewState = ResourceState.PRD_RegularWork
            };
            AppendMessage(msg, ref result);

            msg = new StationStateChanged()
            {
                OldState = ResourceState.PRD_RegularWork,
                OldStateDuration = TimeSpan.FromSeconds(25),
                NewState = ResourceState.USD_ChangeOfConsumables,
                RelatedFault = flt
            };
            AppendMessage(msg, ref result);

            msg = new StageStateChanged()
            {
                Stage = new Stage()
                {
                    StageSequence = 2,
                    StageName = "STAGE2",
                    StageType = StageType.Work
                },
                OldState = ResourceState.SBY_NoProduct,
                OldStateDuration = TimeSpan.FromSeconds(85),
                NewState = ResourceState.PRD_RegularWork
            };
            AppendMessage(msg, ref result);

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = flt
            };
            AppendMessage(msg, ref result);

            msg = new FaultAcknowledged()
            {
                FaultOccurrenceId = flt.FaultOccurrenceId,
                Operator = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "John",
                    LastName = "Doe",
                    LoginName = "john.doe@domain1.com",
                    OperatorIdentifier = "BADGE4486"
                }
            };
            AppendMessage(msg, ref result);

            msg = new FaultCleared()
            {
                FaultOccurrenceId = flt.FaultOccurrenceId,
                Operator = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "John",
                    LastName = "Doe",
                    LoginName = "john.doe@domain1.com",
                    OperatorIdentifier = "BADGE4486"
                }
            };
            AppendMessage(msg, ref result);

            msg = new StationOffline();
            AppendMessage(msg, ref result);

            msg = new StationOnline()
            {
                OfflineDuration = TimeSpan.FromMinutes(23)
            };
            AppendMessage(msg, ref result);

            msg = new ModifyStationParametersRequest()
            {
                NewParameters = new List<Parameter>(new Parameter[]
                {
                    new GenericParameter()
                    {
                        Name = "Torque1",
                        Value = "35.6"
                    }
                }),
            };
            AppendMessage(msg, ref result);

            msg = new ModifyStationParametersResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    ResultCode = 0,
                    Message = "OK"
                },
            };
            AppendMessage(msg, ref result);

            msg = new StationParametersModified()
            {
                ModifiedParameters = new List<Parameter>(new Parameter[]
                {
                    new GenericParameter()
                    {
                        Name = "Torque1",
                        Value = "35.6"
                    }
                }),
            };
            AppendMessage(msg, ref result);

            msg = new StationParametersModified()
            {
                ModifiedParameters = new List<Parameter>(new Parameter []
                {
                    new ReflowOvenParameter()
                    {
                        ConveyorSpeedSetpoint = 50,
                        ConveyorWidth = 25.0,
                        ZoneParameters = new List<ReflowZoneParameter>(new ReflowZoneParameter []
                        {
                            new ReflowZoneParameter()
                            {
                                Zone = new ReflowZone()
                                {
                                    StageSequence = 1,
                                    StageName = "Zone1",
                                    ReflowZoneType = ReflowZoneType.PreHeat
                                },
                                Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                                {
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Top,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 220
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Bottom,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 220
                                    },
                                })
                            },
                            new ReflowZoneParameter()
                            {
                                Zone = new ReflowZone()
                                {
                                    StageSequence = 2,
                                    StageName = "Zone2",
                                    ReflowZoneType = ReflowZoneType.Soak
                                },
                                Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                                {
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Top,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 200
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Bottom,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 220
                                    },
                                })
                            },
                            new ReflowZoneParameter()
                            {
                                Zone = new ReflowZone()
                                {
                                    StageSequence = 3,
                                    StageName = "Zone3",
                                    ReflowZoneType = ReflowZoneType.Reflow
                                },
                                Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                                {
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Top,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 200
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Bottom,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 220
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.WholeZone,
                                        SetpointType = ReflowSetpointType.O2,
                                        Setpoint = 500
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.WholeZone,
                                        SetpointType = ReflowSetpointType.Vacuum,
                                        Setpoint = 2.0
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.WholeZone,
                                        SetpointType = ReflowSetpointType.VacuumHoldTime,
                                        Setpoint = 5.0
                                    },
                                })
                            },
                            new ReflowZoneParameter()
                            {
                                Zone = new ReflowZone()
                                {
                                    StageSequence = 4,
                                    StageName = "Zone4",
                                    ReflowZoneType = ReflowZoneType.Cool
                                },
                                Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                                {
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Top,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 105
                                    },
                                    new ReflowSetPoint()
                                    {
                                        SubZone = ReflowSubZoneType.Bottom,
                                        SetpointType = ReflowSetpointType.Temperature,
                                        Setpoint = 105
                                    },
                                })
                            },
                        }),
                    }
                }),
            };
            AppendMessage(msg, ref result);

            msg = new LogEntryRecorded()
            {
                Importance = LogImportance.Information,
                Message = "Beam 1 Zeroed and Homed",
                InformationId = "INF21321321",
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Lane = 1
            };
            AppendMessage(msg, ref result);

            msg = new MaintenancePerformed()
            {
                MaintenanceJobCode = "MNT113334",
                MaintenanceOrderNumber = "MO676578576",
                ConsumedMaterials = new List<ConsumedMaterial>(new ConsumedMaterial[]
                {
                    new ConsumedMaterial()
                    {
                         QuantityUsed = 3,
                         MaterialLocation = new MaterialLocation()
                         {
                              MaterialPackage = new MaterialPackage()
                              {
                                  InternalPartNumber = "PN2343243"
                              }
                         }
                    },
                    new ConsumedMaterial()
                    {
                         QuantityUsed = 3,
                         MaterialLocation = new MaterialLocation()
                         {
                              MaterialPackage = new MaterialPackage()
                              {
                                  InternalPartNumber = "PN4452",
                                  UniqueIdentifier = "UID23849854385",
                              }
                         }
                    }
                }),
                Tasks = new List<MaintenanceTask>(new MaintenanceTask[]
                {
                    new MaintenanceTask()
                    {
                        Task = "Changed hydraulic fluid in resovoir 1",
                        TaskId = "HYD233432432",
                        ManHoursConsumed = 0.75,
                        Operator = new Operator()
                        {
                            ActorType = ActorType.Human,
                            FirstName = "Joseph",
                            LastName = "Smith",
                            LoginName = "joseph.smith@abcdrepairs.com",
                            OperatorIdentifier = "BADGE489435"
                        }
                    },
                    new MaintenanceTask()
                    {
                        Task = "Checked torque on main mount bolts",
                        TaskId = "CHK3432434",
                        ManHoursConsumed = 0.25,
                        Operator = new Operator()
                        {
                            ActorType = ActorType.Human,
                            FirstName = "Joseph",
                            LastName = "Smith",
                            LoginName = "joseph.smith@abcdrepairs.com",
                            OperatorIdentifier = "BADGE489435"
                        }
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new EnergyConsumed()
            {
                StartTime = DateTime.Now - TimeSpan.FromMinutes(5),
                EndTime = DateTime.Now,
                EnergyUsed = 0.012,
                PeakPower = 125.6,
                MinimumPower = 120.3,
                MeanPower = 124.6
            };
            AppendMessage(msg, ref result);

            SMTPlacementFault smtFlt = new SMTPlacementFault()
            {
                FaultOccurrenceId = Guid.NewGuid(),
                Cause = FaultCause.MechanicalFailure,
                Severity = FaultSeverity.Error,
                FaultCode = "ERROR 3943480",
                Designator = new ComponentDesignator()
                {
                    ReferenceDesignator = "R31",
                    PartNumber = "PN123456"
                },
                PlacementFaultType = SMTPlacementFaultType.PickupError,
                ProgramStep = 56,
                Lane = 1,
                Stage = new Stage()
                {
                    StageSequence = 2,
                    StageName = "STAGE2",
                    StageType = StageType.Work
                },
                MaterialLocation = new MaterialLocation()
                {
                    LocationIdentifier = "UID23948348324",
                    LocationName = "SLOT47",
                    MaterialPackage = new MaterialPackage()
                    {
                        UniqueIdentifier = "UID34280923084932849",
                        InternalPartNumber = "IPN456465465465",
                        Quantity = 854
                    },
                    CarrierInformation = new SMDTapeFeeder()
                    {
                        Name = "8MMFDR231",
                        UniqueIdentifier = "FDR2348934-32890",
                        TapeWidth = 8,
                        TapePitch = 8,
                        LaneNumber = 1
                    }
                },
                HeadAndNozzle = new SMTHeadAndNozzle()
                {
                    UniqueIdentifier = "UID2389432849",
                    Name = "NOZZLE3243244",
                    HeadId = "HEAD1",
                    HeadNozzleNumber = 3,
                    NozzleType = "TYPE914"
                }
            };

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = smtFlt
            };
            AppendMessage(msg, ref result);

            msg = new ToolChanged()
            {
                OldTool = null,
                ReturnedToHolder = null,
                NewTool = new Tool()
                {
                    UniqueIdentifier = "UID23890430",
                    Name = "TorqueWrench_123",
                },
                LoadedFromHolder = new ToolHolder()
                {
                    LocationUniqueIdentifier = "UID238943243243",
                    LocationName = "BIN45",
                }
            };
            AppendMessage(msg, ref result);

            msg = new ToolChanged()
            {
                OldTool = null,
                ReturnedToHolder = null,
                NewTool = new SMTHeadAndNozzle()
                {
                    UniqueIdentifier = "UID23890430",
                    Name = "NOZZLE234324",
                    NozzleType = "TYPE914",
                    HeadId = "HEAD1",
                    HeadNozzleNumber = 1
                },
                LoadedFromHolder = new ToolHolder()
                {
                    LocationUniqueIdentifier = "UID238943243243",
                    LocationName = "HOLDER14",
                    BaseName = "NEST2"
                }
            };
            AppendMessage(msg, ref result);

            msg = new ToolChanged()
            {
                OldTool = null,
                ReturnedToHolder = null,
                NewTool = new SMTStencil()
                {
                    UniqueIdentifier = "UID23890430",
                    Name = "STENCIL234324",
                },
            };
            AppendMessage(msg, ref result);

            msg = new ToolChanged()
            {
                OldTool = null,
                ReturnedToHolder = null,
                NewTool = new SMTSqueegee()
                {
                    UniqueIdentifier = "UID23890430",
                    Name = "SQUEEGEE234324",
                },
            };
            AppendMessage(msg, ref result);

            msg = new CFX.ResourcePerformance.SMTPlacement.ComponentsPlaced()
            {
                StartTime = DateTime.Now - TimeSpan.FromMinutes(10),
                EndTime = DateTime.Now,
                TotalComponentsPlaced = 875,
                TotalComponentsNotPlaced = 45
            };
            AppendMessage(msg, ref result);

            THTInsertionFault thtFlt = new THTInsertionFault()
            {
                FaultOccurrenceId = Guid.NewGuid(),
                Cause = FaultCause.MechanicalFailure,
                Severity = FaultSeverity.Error,
                FaultCode = "ERROR 3943480",
                Designator = new ComponentDesignator()
                {
                    ReferenceDesignator = "R31",
                    PartNumber = "PN123456"
                },
                InsertionFaultType = THTInsertionFaultType.ClinchError,
                ProgramStep = 56,
                Lane = 1,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE2",
                    StageType = StageType.Work
                },
                MaterialLocation = new MaterialLocation()
                {
                    LocationIdentifier = "UID23948348324",
                    LocationName = "SLOT47",
                    MaterialPackage = new MaterialPackage()
                    {
                        UniqueIdentifier = "UID34280923084932849",
                        InternalPartNumber = "IPN456465465465",
                        Quantity = 854
                    },
                    CarrierInformation = new SMDTapeFeeder()
                    {
                        Name = "8MMFDR231",
                        UniqueIdentifier = "FDR2348934-32890",
                        TapeWidth = 8,
                        TapePitch = 8,
                        LaneNumber = 1
                    }
                },
            };

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = thtFlt
            };
            AppendMessage(msg, ref result);

            msg = new CFX.ResourcePerformance.THTInsertion.ComponentsInserted()
            {
                StartTime = DateTime.Now - TimeSpan.FromMinutes(10),
                EndTime = DateTime.Now,
                TotalComponentsInserted = 875,
                TotalComponentsNotInserted = 45
            };
            AppendMessage(msg, ref result);

            msg = new CleanStencilRequest()
            {
                CleanTypeRequested = SMTStencilCleanMode.D
            };
            AppendMessage(msg, ref result);

            msg = new CleanStencilResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new CleanSqueegeeRequest()
            {
                CleanTypeRequested = SMTSqueegeeCleanType.Deep
            };
            AppendMessage(msg, ref result);

            msg = new CleanSqueegeeResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new StencilCleaned()
            {
                Stencil = new SMTStencil()
                {
                    UniqueIdentifier = "UID23432434",
                    Name = "STENCIL234343"
                },
                CyclesSinceLastClean = 35,
                TimeSinceLastClean = TimeSpan.FromMinutes(33),
                StencilCleanCycles = 2,
                StencilCleanMode = SMTStencilCleanMode.V,
                StencilCleanTime = TimeSpan.FromSeconds(38)
            };
            AppendMessage(msg, ref result);

            msg = new SqueegeeCleaned()
            {
                Squeegee = new SMTSqueegee()
                {
                    UniqueIdentifier = "UID23432434",
                    Name = "STENCIL234343"
                },
                CyclesSinceLastClean = 35,
                TimeSinceLastClean = TimeSpan.FromMinutes(33),
                SqueegeeCleanCycles = 2,
                SqueegeeCleanTime = TimeSpan.FromSeconds(38)
            };
            AppendMessage(msg, ref result);

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = new SMTSolderPastePrintingFault()
                {
                    Lane = 1,
                    Stage = new Stage()
                    {
                        StageSequence = 1,
                        StageName = "PRINTSTAGE",
                        StageType = StageType.Work
                    },
                    FaultOccurrenceId = Guid.NewGuid(),
                    Cause = FaultCause.MechanicalFailure,
                    Severity = FaultSeverity.Error,
                    FaultCode = "ERROR 234333",
                    PrintingFaultType = SMTSolderPastePrintingFaultType.SqueegeeError
                }
            };
            AppendMessage(msg, ref result);

            return result;
        }

        public string GenerateMaterials()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new MaterialsLoaded()
            {
                Materials = new List<MaterialLocation>(new MaterialLocation[]
                {
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646453",
                        LocationName = "SLOT45",
                        CarrierInformation = c1,
                        MaterialPackage = m1.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646454",
                        LocationName = "SLOT44",
                        CarrierInformation = c2,
                        MaterialPackage = m2.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646455",
                        LocationName = "SLOT45",
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "1233335A",
                            BaseUniqueIdentifier = "123335",
                            Name = "TAPEFEEDER8mm1233335A",
                            BaseName = "MULTILANEFEEDER123335",
                            TapeWidth = 8,
                            TapePitch = 4
                        },
                        MaterialPackage = m3.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646455",
                        LocationName = "SLOT45",
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "1233335B",
                            BaseUniqueIdentifier = "123335",
                            Name = "TAPEFEEDER8mm1233335B",
                            BaseName = "MULTILANEFEEDER123335",
                            LaneNumber = 2,
                            TapeWidth = 8,
                            TapePitch = 4
                        },
                        MaterialPackage = m4.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646456",
                        LocationName = "SLOT46",
                        CarrierInformation = new SMDTubeFeeder()
                        {
                            UniqueIdentifier = "1233336",
                            BaseUniqueIdentifier = "123336",
                            Name = "TUBE1233336",
                            Width = 12.0,
                            Pitch = 24.0
                        },
                        MaterialPackage = m5.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646457",
                        LocationName = "92.1",
                        CarrierInformation = new SMDTrayFeeder()
                        {
                            UniqueIdentifier = "1233337",
                            Name = "MATRIXTRAY1233337",
                            CellCountX = 8,
                            CellCountY = 3,
                            CellDimensionX = 17.0,
                            CellDimensionY = 17.0,
                        },
                        MaterialPackage = m6.ToMaterialPackage()
                    },
                })

            };
            AppendMessage(msg, ref result);

            msg = new MaterialsUnloaded()
            {
                MaterialPackageIdentifiers = new List<string>(new string[]
                {m1.UniqueIdentifier, m2.UniqueIdentifier, m3.UniqueIdentifier, m4.UniqueIdentifier})
            };
            AppendMessage(msg, ref result);

            msg = new MaterialCarriersLoaded()
            {
                Carriers = new List<MaterialCarrierLocation>(new MaterialCarrierLocation[]
                {
                    new MaterialCarrierLocation()
                    {
                        LocationIdentifier = "5555646453",
                        CarrierInformation = c1,
                    },
                    new MaterialCarrierLocation()
                    {
                        LocationIdentifier = "5555646455",
                        LocationName = "LANEA",
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "1233335A",
                            BaseUniqueIdentifier = "123335",
                            Name = "TAPEFEEDER8mm1233335A",
                            BaseName = "MULTILANEFEEDER123335",
                            TapeWidth = 8,
                            TapePitch = 4
                        },
                    },
                    new MaterialCarrierLocation()
                    {
                        LocationIdentifier = "5555646455",
                        LocationName = "LANEB",
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "1233335B",
                            BaseUniqueIdentifier = "123335",
                            Name = "TAPEFEEDER8mm1233335B",
                            BaseName = "MULTILANEFEEDER123335",
                            LaneNumber = 2,
                            TapeWidth = 8,
                            TapePitch = 4
                        },
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialCarriersUnloaded()
            {
                CarrierIdentifiers = new List<string>(new string[]
                {c2.UniqueIdentifier, c2.UniqueIdentifier})
            };
            AppendMessage(msg, ref result);

            ValidateStationSetupRequest vs = new ValidateStationSetupRequest()
            {
                SetupRequirements = new StationSetupRequirements()
                {
                    SetupName = "COMMONSETUP1",
                }
            };

            vs.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1123", Position = "B1.F.45" });
            vs.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1124", Position = "B1.F.47" });
            vs.SetupRequirements.MaterialSetupRequirements[0].ApprovedAlternateParts.AddRange(new string[] { "IPN2343", "IPN3432" });
            vs.SetupRequirements.MaterialSetupRequirements[1].ApprovedAlternateParts.AddRange(new string[] { "IPN3344", "IPN3376" });
            vs.SetupRequirements.MaterialSetupRequirements[0].ApprovedManufacturerParts.AddRange(new string[] { "MOT4329", "SAM5566" });
            vs.SetupRequirements.MaterialSetupRequirements[1].ApprovedManufacturerParts.AddRange(new string[] { "JP55443", "TX554323" });
            vs.SetupRequirements.ToolSetupRequirements.Add(new ToolSetupRequirement() { PartNumber = "HEADTYPE5566", Position = "MODULE1.BEAM1" });
            vs.SetupRequirements.ToolSetupRequirements.Add(new ToolSetupRequirement() { PartNumber = "HEADTYPE5577", Position = "MODULE1.BEAM2" });
            AppendMessage(vs, ref result);

            msg = new ValidateStationSetupResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "SETUP OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetLoadedMaterialsRequest()
            {
            };
            AppendMessage(msg, ref result);

            msg = new GetLoadedMaterialsResponse()
            {
                Materials = new List<MaterialLocation>(new MaterialLocation[]
                {
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646453",
                        LocationName = "SLOT45",
                        CarrierInformation = c1,
                        MaterialPackage = m1.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646454",
                        LocationName = "SLOT50",
                        CarrierInformation = c2,
                        MaterialPackage = m2.ToMaterialPackage()
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "5555646457",
                        LocationName = "92.1",
                        CarrierInformation = new SMDTrayFeeder()
                        {
                            UniqueIdentifier = "1233337",
                            Name = "MATRIXTRAY1233337",
                            CellCountX = 8,
                            CellCountY = 3,
                            CellDimensionX = 17.0,
                            CellDimensionY = 17.0,
                        },
                        MaterialPackage = m6.ToMaterialPackage()
                    },
                }),
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "SETUP OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new BlockMaterialsRequest()
            {
                Reason = BlockReason.SuspectedProblem,
                Comments = "Suspected Bad Lot of Parts",
                MaterialPackageIdentifiers = new List<string>(new string[]
                 {
                     m1.UniqueIdentifier, m2.UniqueIdentifier
                 })
            };
            AppendMessage(msg, ref result);

            msg = new BlockMaterialsResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetMaterialInformationRequest()
            {
                MaterialPackageIdentifiers = new List<string>()
                {
                    m1.UniqueIdentifier, m2.UniqueIdentifier
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetMaterialInformationResponse()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m2
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsInitialized()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m2
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsJoined()
            {
                LeadingMaterialPackage = m6.ToMaterialPackage(),
                TrailingMaterialPackage = m7.ToMaterialPackage()
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsModified()
            {
                Reason = MaterialModifyReason.ManualCountAndQuantityUpdate,
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m2, m3
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsRetired()
            {
                Materials = new List<MaterialPackage>(new MaterialPackage[]
                {
                    m1.ToMaterialPackage(), m2.ToMaterialPackage(), m3.ToMaterialPackage()
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsSplit()
            {
                SourceMaterialPackageIdentifier = m6.UniqueIdentifier,
                SourceMaterialPackageRemainingQuantity = m6.Quantity - 30,
                NewMaterialPackageIdentifier = m7.UniqueIdentifier,
                NewMaterialPackageQuantity = 30
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsConsumed()
            {
                ConsumedMaterials = new List<ConsumedMaterial>(new ConsumedMaterial[]
                {
                    new ConsumedMaterial()
                    {
                        MaterialLocation = new MaterialLocation()
                        {
                            LocationIdentifier = "3245434554",
                            LocationName = "SLOT22",
                            MaterialPackage = new MaterialPackage()
                            {
                                UniqueIdentifier = "MAT238908348903",
                                InternalPartNumber = "IPN-1222-55555",
                                Quantity = 344
                            },
                            CarrierInformation = new SMDTapeFeeder()
                            {
                                UniqueIdentifier = "234232432424",
                                Name = "FEEDER2245465",
                                TapeWidth = 8,
                                TapePitch = 4
                            }
                        },
                        QuantityUsed = 42,
                        QuantitySpoiled = 2,
                        RemainingQuantity = 344
                    },
                    new ConsumedMaterial()
                    {
                        MaterialLocation = new MaterialLocation()
                        {
                            LocationIdentifier = "3245435784",
                            LocationName = "SLOT28",
                            MaterialPackage = new MaterialPackage()
                            {
                                UniqueIdentifier = "MAT238908323434",
                                InternalPartNumber = "IPN-1222-11111",
                                Quantity = 258
                            },
                            CarrierInformation = new SMDTapeFeeder()
                            {
                                UniqueIdentifier = "234232432424",
                                Name = "FEEDER2245465",
                                TapeWidth = 8,
                                TapePitch = 4
                            }
                        },
                        QuantityUsed = 88,
                        QuantitySpoiled = 3,
                        RemainingQuantity = 258
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new MaterialsEmpty()
            {
                EmptyMaterials = new List<MaterialLocation>(new MaterialLocation[]
                {
                    new MaterialLocation()
                    {
                        LocationIdentifier = "3245434554",
                        LocationName = "SLOT22",
                        MaterialPackage = new MaterialPackage()
                        {
                            UniqueIdentifier = "MAT238908348903",
                            InternalPartNumber = "IPN-1222-55555",
                            Quantity = 0
                        },
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "234232432424",
                            Name = "FEEDER2245465",
                            TapeWidth = 8,
                            TapePitch = 8
                        }
                    },
                    new MaterialLocation()
                    {
                        LocationIdentifier = "3245435784",
                        LocationName = "SLOT28",
                        MaterialPackage = new MaterialPackage()
                        {
                            UniqueIdentifier = "MAT238908323434",
                            InternalPartNumber = "IPN-1222-11111",
                            Quantity = 0
                        },
                        CarrierInformation = new SMDTapeFeeder()
                        {
                            UniqueIdentifier = "234232432424",
                            Name = "FEEDER2245465",
                            TapeWidth = 8,
                            TapePitch = 4
                        }
                    },
                })
            };
            AppendMessage(msg, ref result);

            msg = new SplicePointDetected()
            {
                DepletedMaterial = new MaterialLocation()
                {
                    LocationIdentifier = "3245434554",
                    LocationName = "SLOT22",
                    MaterialPackage = new MaterialPackage()
                    {
                        UniqueIdentifier = "MAT238908348903",
                        InternalPartNumber = "IPN-1222-55555",
                        Quantity = 0
                    },
                    CarrierInformation = new SMDTapeFeeder()
                    {
                        UniqueIdentifier = "234232432424",
                        Name = "FEEDER2245465",
                        TapeWidth = 8,
                        TapePitch = 8
                    }
                },
                NewlyActiveMaterial = new MaterialLocation()
                {
                    LocationIdentifier = "3245435784",
                    LocationName = "SLOT28",
                    MaterialPackage = new MaterialPackage()
                    {
                        UniqueIdentifier = "MAT238908348904",
                        InternalPartNumber = "IPN-1222-55555",
                        Quantity = 1000
                    },
                    CarrierInformation = new SMDTapeFeeder()
                    {
                        UniqueIdentifier = "234232432424",
                        Name = "FEEDER2245465",
                        TapeWidth = 8,
                        TapePitch = 8
                    }
                }
            };
            AppendMessage(msg, ref result);

            (m1.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m1.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m1.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m1.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            (m3.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m3.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m3.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m3.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            msg = new MaterialsOpened()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m3
                })
            };
            AppendMessage(msg, ref result);

            (m1.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Expired;
            (m1.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now;
            (m3.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Expired;
            (m3.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now;
            msg = new MaterialsExpired()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m3
                })
            };
            AppendMessage(msg, ref result);

            (m1.MaterialData as MaterialPackageMSDData).MSDState = MSDState.InDryStorage;
            (m1.MaterialData as MaterialPackageMSDData).ExpirationDateTime = null;
            (m3.MaterialData as MaterialPackageMSDData).MSDState = MSDState.InDryStorage;
            (m3.MaterialData as MaterialPackageMSDData).ExpirationDateTime = null;
            msg = new MaterialsPlacedInDryStorage()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m3
                })
            };
            AppendMessage(msg, ref result);

            (m1.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m1.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m1.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m1.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            (m3.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m3.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m3.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m3.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            msg = new MaterialsRemovedFromDryStorage()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m3
                })
            };
            AppendMessage(msg, ref result);

            (m1.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m1.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m1.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m1.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            (m3.MaterialData as MaterialPackageMSDData).MSDState = MSDState.Exposed;
            (m3.MaterialData as MaterialPackageMSDData).LastExposureDateTime = DateTime.Now;
            (m3.MaterialData as MaterialPackageMSDData).ExpirationDateTime = DateTime.Now + (m3.MaterialData as MaterialPackageMSDData).RemainingExposureTime;
            msg = new MaterialsRestored()
            {
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail[]
                {
                    m1, m3
                })
            };
            AppendMessage(msg, ref result);

            Operator o1 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "Bill",
                LastName = "Smith",
                LoginName = "bill.smith@domain1.com",
                OperatorIdentifier = "BADGE4485"
            };

            Operator o2 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "John",
                LastName = "Doe",
                LoginName = "john.doe@domain1.com",
                OperatorIdentifier = "BADGE4486"
            };

            Operator o3 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "Mike",
                LastName = "Dolittle",
                LoginName = "mike.dolittle@domain1.com",
                OperatorIdentifier = "BADGE4487"
            };

            msg = new TransportOrderStarted()
            {
                TransportOrderId = "TR329483249830000",
                Status = TransportOrderStatus.Pending,
                Comments = "Initiating new transport order.  Waiting to be kitted.",
                FinalDestination = "LINE1",
                NextCheckpoint = "SMT STAGING AREA 1",
                RelatedWorkOrderId = "WO2384702937403280032",
                StartedBy = o1
            };
            AppendMessage(msg, ref result);

            msg = new TransportOrderStatusChanged()
            {
                TransportOrderId = "TR329483249830000",
                Status = TransportOrderStatus.Kitting,
                Comments = "Kitting Underway...",
                FinalDestination = "LINE 1",
                NextCheckpoint = "SMT STAGING AREA 1",
                RelatedWorkOrderId = "WO2384702937403280032",
                UpdatedBy = o1
            };
            AppendMessage(msg, ref result);

            msg = new CheckpointReached()
            {
                TransportOrderId = "TR329483249830000",
                Status = TransportOrderStatus.InTransit,
                Comments = "Arrived SMT Production Area",
                Checkpoint = "SMT STAGING AREA 1",
                FinalDestination = "LINE 1",
                NextCheckpoint = "LINE 1",
                RelatedWorkOrderId = "WO2384702937403280032",
                TrackedBy = o2
            };
            AppendMessage(msg, ref result);

            msg = new TransportOrderCompleted()
            {
                TransportOrderId = "TR329483249830000",
                Comments = "Received at Line 1",
                FinalDestination = "LINE 1",
                RelatedWorkOrderId = "WO2384702937403280032",
                AcceptedBy = o3
            };
            AppendMessage(msg, ref result);

            msg = new GetTransportOrderStatusRequest()
            {
                TransportOrderId = "TR329483249830000",
            };
            AppendMessage(msg, ref result);

            msg = new GetTransportOrderStatusResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                },
                TransportOrderId = "TR329483249830000",
                FinalDestination = "LINE 1",
                Status = TransportOrderStatus.Delivered,
                History = new List<TransportOrderHistory>(new TransportOrderHistory[]
                {
                    new TransportOrderHistory()
                    {
                        EventDateTime = new DateTime(2017,11,1,11,55,00),
                        Location = "STOCK ROOM 1",
                        Status = TransportOrderStatus.Kitting,
                        Operator = o1,
                    },
                    new TransportOrderHistory()
                    {
                        EventDateTime = new DateTime(2017,11,1,14,25,00),
                        Location = "STOCK ROOM 1",
                        Status = TransportOrderStatus.Kitted,
                        Operator = o1,
                    },
                    new TransportOrderHistory()
                    {
                        EventDateTime = new DateTime(2017,11,1,15,45,00),
                        Location = "STOCK ROOM 1",
                        Status = TransportOrderStatus.InTransit,
                        Operator = o1,
                    },
                    new TransportOrderHistory()
                    {
                        EventDateTime = new DateTime(2017,11,1,16,55,00),
                        Location = "SMT STAGING AREA 1",
                        Status = TransportOrderStatus.InTransit,
                        Operator = o2,
                    },
                    new TransportOrderHistory()
                    {
                        EventDateTime = new DateTime(2017,11,1,17,22,00),
                        Location = "LINE1",
                        Status = TransportOrderStatus.Delivered,
                        Operator = o3,
                    }
                })
            };
            AppendMessage(msg, ref result);


            return result;
        }

        public string GenerateProduction()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new ActivateRecipeRequest()
            {
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Lane = 1,
                RecipeName = "RECIPE1234",
                Revision = "C"
            };
            AppendMessage(msg, ref result);

            msg = new ActivateRecipeResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetActiveRecipeRequest()
            {
                Lane = 1,
            };
            AppendMessage(msg, ref result);

            msg = new GetActiveRecipeResponse()
            {
                ActiveRecipeName = "RECIPE5566",
                ActiveRecipeRevision = "C",
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetRecipeRequest()
            {
                RecipeName = "RECIPE3234"
            };
            AppendMessage(msg, ref result);

            msg = new GetRecipeResponse()
            {
                Recipe = new Recipe()
                {
                    Name = "RECIPE4455",
                    MimeType = "application/octet-stream",
                    RecipeData = new byte[] { 0x11, 0x22, 0x88, 0x99, 0x23, 0x55, 0x66, 0x53 }
                }
            };
            AppendMessage(msg, ref result);

            msg = new GetRequiredSetupRequest()
            {
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Lane = 1,
            };
            AppendMessage(msg, ref result);

            GetRequiredSetupResponse grsr = new GetRequiredSetupResponse()
            {
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Lane = 1,
                RecipeName = "RECIPE4455",
                RecipeRevision = "C",
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                },
                SetupRequirements = new StationSetupRequirements()
                {
                    Stage = new Stage()
                    {
                        StageSequence = 1,
                        StageName = "STAGE1",
                        StageType = StageType.Work
                    },
                    Lane = 1,
                    SetupName = "COMMONSETUP45",
                }
            };
            grsr.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1123", Position = "B1.F.45" });
            grsr.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1124", Position = "B1.F.47" });
            grsr.SetupRequirements.MaterialSetupRequirements[0].ApprovedAlternateParts.AddRange(new string[] { "IPN2343", "IPN3432" });
            grsr.SetupRequirements.MaterialSetupRequirements[1].ApprovedAlternateParts.AddRange(new string[] { "IPN3344", "IPN3376" });
            grsr.SetupRequirements.MaterialSetupRequirements[0].ApprovedManufacturerParts.AddRange(new string[] { "MOT4329", "SAM5566" });
            grsr.SetupRequirements.MaterialSetupRequirements[1].ApprovedManufacturerParts.AddRange(new string[] { "JP55443", "TX554323" });
            grsr.SetupRequirements.ToolSetupRequirements.Add(new ToolSetupRequirement() { PartNumber = "HEADTYPE5566", Position = "MODULE1.BEAM1" });
            grsr.SetupRequirements.ToolSetupRequirements.Add(new ToolSetupRequirement() { PartNumber = "HEADTYPE5577", Position = "MODULE1.BEAM2" });

            AppendMessage(grsr, ref result);

            msg = new LockStationRequest()
            {
                Reason = LockReason.QualityIssue,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Lane = 1,
                Requestor = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = "BADGE4489"
                }
            };
            AppendMessage(msg, ref result);

            msg = new LockStationResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new OperatorActivated()
            {
                Operator = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = "BADGE489435"
                }
            };
            AppendMessage(msg, ref result);

            msg = new OperatorDeactivated()
            {
                Operator = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = "BADGE489435"
                }
            };
            AppendMessage(msg, ref result);

            msg = new ReadingsRecorded()
            {
                TransactionId = Guid.NewGuid(),
                Readings = new List<Reading>(new Reading[] {
                    new Reading() { ReadingIdentifier = "CHIPTEMP1", ReadingSequence = 1, ValueDataType = DataType.Numeric, Value = "18.1", ValueUnits = "C",
                                    ExpectedValue = "17.5", ExpectedValueUnits = "C", MaximumAcceptableValue = "18.9", MinimumAcceptableValue = "11.5",
                                    Result = TestResult.Passed, TimeRecorded = DateTime.Now, UnitPositionNumber = 1,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "U22", PartNumber = "IPN11234" }
                                    }) },
                   new Reading() { ReadingIdentifier = "VOLTAGE1", ReadingSequence = 2, ValueDataType = DataType.Numeric, Value = "220.56", ValueUnits = "VDC",
                                    ExpectedValue = "221.50", ExpectedValueUnits = "VDC", MaximumAcceptableValue = "223.0", MinimumAcceptableValue = "220.0",
                                    Result = TestResult.Passed, TimeRecorded = DateTime.Now, UnitPositionNumber = 1,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "R11", PartNumber = "IPN11222" },
                                        new ComponentDesignator() { ReferenceDesignator = "C12", PartNumber = "IPN11569" },
                                        new ComponentDesignator() { ReferenceDesignator = "R56", PartNumber = "IPN11222" }
                                    }) },
                   new Reading() { ReadingIdentifier = "CHIPTEMP1", ReadingSequence = 1, ValueDataType = DataType.Numeric, Value = "18.9", ValueUnits = "C",
                                    ExpectedValue = "17.5", ExpectedValueUnits = "C", MaximumAcceptableValue = "18.9", MinimumAcceptableValue = "11.5",
                                    Result = TestResult.Passed, TimeRecorded = DateTime.Now, UnitPositionNumber = 2,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "U22", PartNumber = "IPN11234" }
                                    }) },
                   new Reading() { ReadingIdentifier = "VOLTAGE1", ReadingSequence = 2, ValueDataType = DataType.Numeric, Value = "221.56", ValueUnits = "VDC",
                                    ExpectedValue = "221.50", ExpectedValueUnits = "VDC", MaximumAcceptableValue = "223.0", MinimumAcceptableValue = "220.0",
                                    Result = TestResult.Passed, TimeRecorded = DateTime.Now, UnitPositionNumber = 2,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "R11", PartNumber = "IPN11222" },
                                        new ComponentDesignator() { ReferenceDesignator = "C12", PartNumber = "IPN11569" },
                                        new ComponentDesignator() { ReferenceDesignator = "R56", PartNumber = "IPN11222" }
                                    }) }
                })
            };
            AppendMessage(msg, ref result);

            /********       Commented by DanieleASM because the compilation fail:
             * No constructor for the RecipeActivated() as provided in this message.
             * Please fix this bug with the appropriate constructor
             *****************************************************************************/
            msg = new RecipeActivated()
            {
                Lane = 1,
                RecipeName = "RECIPE3234",
                Revision = "B",
                WorkOrderIdentifier = new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO-1000-1000",
                    Batch = "WO-1000-1000-B1"
                },
                RelevantSurface = Surface.PrimarySurface,
                TargetQuantity = 500
                               
            };
            AppendMessage(msg, ref result);

            msg = new RecipeModified()
            {
                RecipeName = "RECIPE3234",
                Revision = "D",
                ModifiedBy = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = "BADGE489435"
                },
                Reason = RecipeModificationReason.PositionalCorrection
            };
            AppendMessage(msg, ref result);

            msg = new SetupRequirementsChanged()
            {
                Lane = 1,
            };
            AppendMessage(msg, ref result);

            msg = new UnitsInitialized()
            {
                WorkOrderIdentifier = new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO45648798",
                    Batch = "BATCH45648798-1"
                },
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "UNIT5566687", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "UNIT5566688", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsArrived()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsDeparted()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsDisqualified()
            {
                Reason = DisqualificationReason.DefectiveRepairNotPossible,
                Comments = "The units were accidentally dropped, and irrepairably damaged",
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnlockStationRequest()
            {
                Requestor = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = "BADGE489435"
                }
            };
            AppendMessage(msg, ref result);

            msg = new UnlockStationResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new UpdateRecipeRequest()
            {
                Overwrite = true,
                Recipe = new Recipe()
                {
                    Name = "RECIPE234324",
                    Revision = "C",
                    MimeType = "application/octet-stream",
                    RecipeData = new byte[] { 0xff, 0xfc, 0x34 }
                },
                Reason = RecipeModificationReason.NewRevision
            };
            AppendMessage(msg, ref result);

            //Including printing extension from Recipe base class
            //Modified according to email thread ASM - John W.
            msg = new UpdateRecipeRequest()
            {
                Overwrite = true,
                Recipe = new SolderPastePrintingRecipe()
                {
                    Name = "RECIPE234324",
                    Revision = "C",
                    UnitLength = 22.46,
                    UnitWidth = 19.21,
                    UnitHeight = 0.85,
                    ExpectedCycleTime = 46.25,
                    ExpectedUnitsPerWorkTransaction = 4,
                    Strokes = new List<Stroke>(
                        new Stroke[]
                        {
                            new Stroke() {PrintPressure = 1, PrintSpeed = 12 },
                            new Stroke() { PrintPressure = 2, PrintSpeed = 9 }
                        }),
                    PrintGap = 1.2,
                    Separation = new Separation() { SeparationDistance = 1.2, SeparationSpeed = 1.6 },
                    PeriodicCleanings = new List<PeriodicCleaning>(
                        new PeriodicCleaning[]
                        {
                            new PeriodicCleaning(){CleanFrequency = 2, CleanMode= "W"}
                        })
                },
                Reason = RecipeModificationReason.NewRevision,
            };

            AppendMessage(msg, ref result);

            msg = new UpdateRecipeResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            Guid transId = Guid.Parse("{2C24590D-39C5-4039-96A5-91900CECEDFA}");

            msg = new WorkCompleted()
            {
                TransactionID = transId,
                Result = WorkResult.Completed
            };
            AppendMessage(msg, ref result);

            msg = new WorkStageCompleted()
            {
                TransactionID = transId,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
            };
            AppendMessage(msg, ref result);

            msg = new WorkStagePaused()
            {
                TransactionID = transId,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
            };
            AppendMessage(msg, ref result);

            msg = new WorkStageResumed()
            {
                TransactionID = transId,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
            };
            AppendMessage(msg, ref result);

            msg = new WorkStageStarted()
            {
                TransactionID = transId,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
            };
            AppendMessage(msg, ref result);

            Guid actId = Guid.NewGuid();
            msg = new ActivitiesExecuted()
            {
                TransactionID = transId,
                Stage = new Stage()
                {
                    StageSequence = 1,
                    StageName = "STAGE1",
                    StageType = StageType.Work
                },
                Activities = new List<Activity>(new Activity[]
                {
                    new UnitLoadActivity()
                    {
                        TimeStamp = DateTime.Now - TimeSpan.FromSeconds(55),
                        LoadTime = TimeSpan.FromSeconds(5.3),
                    },
                    new UnitAlignmentActivity()
                    {
                        TimeStamp = DateTime.Now - TimeSpan.FromSeconds(55),
                        ActivityState = ActivityState.Started,
                        ActivityInstanceId = actId
                    },
                    new UnitAlignmentActivity()
                    {
                        TimeStamp = DateTime.Now - TimeSpan.FromSeconds(50),
                        ActivityInstanceId = actId,
                        DX = 0.125,
                        DY = 0.104,
                        DXY = 0.987
                    },
                    new SMTNozzleChangeActivity()
                    {
                        TimeStamp = DateTime.Now - TimeSpan.FromSeconds(30),
                        NewNozzles = new List<SMTHeadAndNozzle>(new SMTHeadAndNozzle []
                        {
                            new SMTHeadAndNozzle()
                            {
                                UniqueIdentifier = "UID234213421",
                                Name = "Nozzle45",
                                NozzleType = "409A",
                                HeadId = "HEAD1",
                                HeadNozzleNumber = 1
                            },
                            new SMTHeadAndNozzle()
                            {
                                UniqueIdentifier = "UID234213421",
                                Name = "Nozzle32",
                                NozzleType = "302B",
                                HeadId = "HEAD1",
                                HeadNozzleNumber = 2
                            },
                        }),
                    },
                    new UnitUnloadActivity()
                    {
                        UnloadTime = TimeSpan.FromSeconds(3.2),
                    },
                }),
            };
            AppendMessage(msg, ref result);

            msg = new WorkStarted()
            {
                TransactionID = transId,
                Lane = 1,
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 70.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new ValidateUnitsRequest()
            {
                PrimaryIdentifier = "CARRIER2342",
                Validations = new List<ValidationType>(
                    new ValidationType[]
                    {
                        ValidationType.UnitRouteValidation,
                        ValidationType.UnitStatusValidation
                    }),
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 70.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new ValidateUnitsResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                },
                PrimaryResult = new ValidationResult()
                {
                    Result = ValidationStatus.Passed,
                    UniqueIdentifier = "CARRIER5566",
                    Message = "OK",
                    FailureCode = 0,
                },

                ValidationResults = new List<ValidationResult>(new ValidationResult[]
                {
                    new ValidationResult()
                    {
                        Result = ValidationStatus.Passed,
                        UniqueIdentifier = "CARRIER5566",
                        PositionNumber = 1,
                        Message = "OK",
                        FailureCode = 0,
                    },
                    new ValidationResult()
                    {
                        Result = ValidationStatus.Passed,
                        UniqueIdentifier = "CARRIER5566",
                        PositionNumber = 2,
                        Message = "OK",
                        FailureCode = 0,
                    }
                })
            };
            AppendMessage(msg, ref result);

            msg = new IdentifyUnitsRequest();
            AppendMessage(msg, ref result);

            msg = new IdentifyUnitsResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                },
                PrimaryIdentifier = "CARRIER21342",
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new IdentifiersRead()
            {
                PrimaryIdentifier = "CARRIER21342",
            };
            AppendMessage(msg, ref result);

            msg = new IdentifiersRead()
            {
                PrimaryIdentifier = "CARRIER21342",
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER21342", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 2, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER21342", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new IdentifiersNotRead()
            {
            };
            AppendMessage(msg, ref result);

            msg = new IdentifiersNotRead()
            {
                PositionsNotRead = new List<int>(new int[] { 2, 8 })
            };
            AppendMessage(msg, ref result);

            msg = new BlockMaterialLocationsRequest()
            {
                Reason = BlockReason.ExpiredMaterial,
                Comments = "MSD Material Has Expired",
                Locations = new List<MaterialLocation>(
                   new MaterialLocation[]
                   {
                        new MaterialLocation() { LocationIdentifier = "23143433", LocationName = "SLOT45"},
                        new MaterialLocation() { LocationIdentifier = "23143454", LocationName = "SLOT46"},
                   })
            };
            AppendMessage(msg, ref result);

            msg = new BlockMaterialLocationsResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new UnblockMaterialLocationsRequest()
            {
                Locations = new List<MaterialLocation>(
                   new MaterialLocation[]
                   {
                        new MaterialLocation() { LocationIdentifier = "23143433", LocationName = "SLOT45"},
                        new MaterialLocation() { LocationIdentifier = "23143454", LocationName = "SLOT46"},
                   })
            };
            AppendMessage(msg, ref result);

            msg = new UnblockMaterialLocationsResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new UnitsProcessed()
            {
                TransactionId = Guid.NewGuid(),
                CommonProcessData = new ReflowProcessData()
                {
                    ConveyorSpeed = 60,
                    ZoneData = new List<ReflowZoneData>(new ReflowZoneData []
                    {
                        new ReflowZoneData()
                        {
                            Zone = new ReflowZone()
                            {
                                StageSequence = 1,
                                StageName = "Zone1",
                                StageType = StageType.Work,
                                ReflowZoneType = ReflowZoneType.PreHeat
                            },
                            Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                            {
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 220
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 210
                                },
                            }),
                            Readings = new List<ReflowReading>(new ReflowReading []
                            {
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 221,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 220,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 55,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 209,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 195,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 45,
                                },
                            })
                        },
                        new ReflowZoneData()
                        {
                            Zone = new ReflowZone()
                            {
                                StageSequence = 2,
                                StageName = "Zone2",
                                StageType = StageType.Work,
                                ReflowZoneType = ReflowZoneType.Soak
                            },
                            Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                            {
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 200
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 190
                                },
                            }),
                            Readings = new List<ReflowReading>(new ReflowReading []
                            {
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 201,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 190,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 45,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 189.5,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 185,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 42,
                                },
                            })
                        },
                        new ReflowZoneData()
                        {
                            Zone = new ReflowZone()
                            {
                                StageSequence = 3,
                                StageName = "Zone3",
                                StageType = StageType.Work,
                                ReflowZoneType = ReflowZoneType.Reflow
                            },
                            Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                            {
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 250
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 240
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    SetpointType = ReflowSetpointType.O2,
                                    Setpoint = 500
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    SetpointType = ReflowSetpointType.Vacuum,
                                    Setpoint = 225
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    SetpointType = ReflowSetpointType.VacuumHoldTime,
                                    Setpoint = 5
                                },
                            }),
                            Readings = new List<ReflowReading>(new ReflowReading []
                            {
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 251,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 230,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 75,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 239.5,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 220,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 65,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    ReadingType = ReflowReadingType.O2,
                                    ReadingValue = 498,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    ReadingType = ReflowReadingType.Vacuum,
                                    ReadingValue = 224,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    ReadingType = ReflowReadingType.VacuumHoldTime,
                                    ReadingValue = 5,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.WholeZone,
                                    ReadingType = ReflowReadingType.ConvectionRate,
                                    ReadingValue = 250,
                                },
                            })
                        },
                        new ReflowZoneData()
                        {
                            Zone = new ReflowZone()
                            {
                                StageSequence = 4,
                                StageName = "Zone4",
                                StageType = StageType.Work,
                                ReflowZoneType = ReflowZoneType.Cool
                            },
                            Setpoints = new List<ReflowSetPoint>(new ReflowSetPoint []
                            {
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 150
                                },
                                new ReflowSetPoint()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    SetpointType = ReflowSetpointType.Temperature,
                                    Setpoint = 140
                                },
                            }),
                            Readings = new List<ReflowReading>(new ReflowReading []
                            {
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 151,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 120,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Top,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 30,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Temperature,
                                    ReadingValue = 139,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.Power,
                                    ReadingValue = 110,
                                },
                                new ReflowReading()
                                {
                                    SubZone = ReflowSubZoneType.Bottom,
                                    ReadingType = ReflowReadingType.PowerLevel,
                                    ReadingValue = 25,
                                },
                            })
                        },
                    }),
                }
            };

            AppendMessage(msg, ref result);

            List<ReflowZoneData> zoneData = (((msg as UnitsProcessed).CommonProcessData) as ReflowProcessData).ZoneData;
            
            msg = new UnitsProcessed()
            {
                TransactionId = Guid.NewGuid(),
                UnitProcessData = new List<ProcessedUnit>(new ProcessedUnit[]
                {
                    new ProcessedUnit()
                    {
                        UnitIdentifier = "CARRIER55678",
                        UnitPositionNumber = 1,
                        UnitProcessData = new CoatingProcessData()
                        {
                            Readings = new List<CoatingMeasurement>(new CoatingMeasurement []
                            {
                                new CoatingMeasurement()
                                {
                                    MeasurementType = CoatingMeasurementType.FluidVolume,
                                    ActualValue = 1.1,
                                    ExpectedValue = 1.0,
                                    MinAcceptableValue = 0.8,
                                    MaxAcceptableValue = 1.2
                                },
                                new CoatingMeasurement()
                                {
                                    MeasurementType = CoatingMeasurementType.FluidPressure,
                                    ActualValue = 32.5,
                                    ExpectedValue = 32.0,
                                    MinAcceptableValue = 31.0,
                                    MaxAcceptableValue = 33.8
                                },
                            }),
                        }
                    },
                    new ProcessedUnit()
                    {
                        UnitIdentifier = "CARRIER55678",
                        UnitPositionNumber = 2,
                        UnitProcessData = new CoatingProcessData()
                        {
                            Readings = new List<CoatingMeasurement>(new CoatingMeasurement []
                            {
                                new CoatingMeasurement()
                                {
                                    MeasurementType = CoatingMeasurementType.FluidVolume,
                                    ActualValue = 1.1,
                                    ExpectedValue = 1.0,
                                    MinAcceptableValue = 0.8,
                                    MaxAcceptableValue = 1.2
                                },
                                new CoatingMeasurement()
                                {
                                    MeasurementType = CoatingMeasurementType.FluidPressure,
                                    ActualValue = 32.5,
                                    ExpectedValue = 32.0,
                                    MinAcceptableValue = 31.0,
                                    MaxAcceptableValue = 33.8
                                },
                            }),
                        }
                    }

                }),

            };

            AppendMessage(msg, ref result);


            msg = new UnitsProcessed()
            {
                TransactionId = Guid.NewGuid(),
                CommonProcessData = new ReflowProfilingProcessData()
                {
                    Barcode = "CARRIER55678",
                    ConveyorSpeedSetpoint = 100,
                    MeasuredConveyorSpeed = 102.3,
                    Lane = 1,
                    OvenName = "Oven1",
                    LotID = "Lot5564",
                    ProductName = "Product1",
                    RecipeName = "Recipe1",
                    ProcessWindowName = "ProcessWindow001",
                    Result = TestResult.Passed,
                    TimeDateUnitIn = DateTime.Now,
                    TimeDateUnitOut = DateTime.Now + TimeSpan.FromSeconds(82),
                    ProductionUnitPWI = 89.6,
                    ZoneData = zoneData
                },
            };

            AppendMessage(msg, ref result);

            //New UnitsProcess to have the PrintigPCB data
            msg = new UnitsProcessed()
            {
                TransactionId = Guid.NewGuid(),
                OverallResult = ProcessingResult.Succeeded,
                CommonProcessData = new SolderPastePrintingPCBProcessData()
                {
                    Strokes = new List<Stroke>(
                        new Stroke[]
                        {
                        new Stroke() {PrintPressure = 1, PrintSpeed = 12},
                        new Stroke() { PrintPressure = 2, PrintSpeed = 9 }
                        }),
                    
                    Separation = new Separation() { SeparationDistance = 1.2, SeparationSpeed = 1.6 },

                    PeriodicCleanings = new List<PeriodicCleaning>(
                           new PeriodicCleaning[]
                           {
                               new PeriodicCleaning(){CleanFrequency = 2, CleanMode= "W"}
                           }),
                    RecipeName = "RECIPE_123",
                    FirstPrintDirection = "FrontToRear",
                    OffsetX= 1.5,
                    OffsetY= 0.5,
                    OffsetTheta= 2.5
                },
            };

            AppendMessage(msg, ref result);

            return result;
        }

        private void AppendMessage(CFXMessage msg, ref string data)
        {
            string type = msg.GetType().ToString();
            string sep = new string('=', type.Length);
            data += type + "\r\n" + sep + "\r\n";
            string jsonData = msg.ToJson(true) + "\r\n";

            data += "/// <code language=\"none\">\r\n";
            foreach (string line in jsonData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                data += "/// ";
                data += line;
                data += "\r\n";
            }
            data += "/// </code>\r\n\r\n\r\n";
        }

        public void InitializeMaterials()
        {
            op1 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "Joseph",
                LastName = "Smith",
                LoginName = "joseph.smith@abcdrepairs.com",
                OperatorIdentifier = "BADGE489435"
            };

            m1 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566556456",
                InternalPartNumber = "IPN47788",
                Manufacturer = "MOTOROLA",
                ManufacturerPartNumber = "MOT231234",
                ManufacturerLotCode = "LOT2016110588",
                ManufactureDate = new DateTime(2016, 11, 5),
                Vendor = "Digikey",
                VendorPartNumber = "DIG23452442",
                ReceivedDate = new DateTime(2017, 5, 6),
                Status = MaterialStatus.Active,
                HazardousMaterialType = HazardousMaterialType.RoHS,
                InitialQuantity = 1000,
                Quantity = 887,
                MaterialData = new MaterialPackageMSDData()
                {
                    MSDLevel = MSDLevel.MSL3,
                    MSDState = MSDState.InDryStorage,
                    OriginalExposureDateTime = new DateTime(2017, 05, 01, 08, 22, 12),
                    LastExposureDateTime = new DateTime(2017, 05, 06, 13, 55, 33),
                    RemainingExposureTime = new TimeSpan(144, 0, 0),
                }
            };

            m2 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566554543",
                InternalPartNumber = "IPN48899",
                Manufacturer = "SAMSUNG",
                ManufacturerPartNumber = "SAM233243",
                ManufacturerLotCode = "LOT2016101008",
                ManufactureDate = new DateTime(2016, 10, 10),
                Vendor = "Digikey",
                VendorPartNumber = "DIG44543534",
                ReceivedDate = new DateTime(2017, 9, 9),
                Status = MaterialStatus.Active,
                InitialQuantity = 1000,
                Quantity = 748
            };

            m3 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566553421",
                InternalPartNumber = "IPN45577",
                Manufacturer = "FUJITSU",
                ManufacturerPartNumber = "FJJT234243",
                ManufacturerLotCode = "LOT2017080355",
                ManufactureDate = new DateTime(2017, 08, 3),
                Vendor = "Digikey",
                VendorPartNumber = "DIG543534537",
                ReceivedDate = new DateTime(2017, 9, 10),
                Status = MaterialStatus.Active,
                InitialQuantity = 500,
                Quantity = 151,
                MaterialData = new MaterialPackageMSDData()
                {
                    MSDLevel = MSDLevel.MSL2A,
                    MSDState = MSDState.Exposed,
                    OriginalExposureDateTime = new DateTime(2017, 05, 01, 08, 22, 12),
                    LastExposureDateTime = new DateTime(2017, 05, 06, 13, 55, 33),
                    RemainingExposureTime = new TimeSpan(144, 0, 0),
                }
            };

            m4 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566555547",
                InternalPartNumber = "IPN45577",
                Manufacturer = "FUJITSU",
                ManufacturerPartNumber = "FJJT234243",
                ManufacturerLotCode = "LOT2017080355",
                ManufactureDate = new DateTime(2017, 08, 3),
                Vendor = "Digikey",
                VendorPartNumber = "DIG543534537",
                ReceivedDate = new DateTime(2017, 9, 10),
                Status = MaterialStatus.Active,
                InitialQuantity = 500,
                Quantity = 151
            };

            m5 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566588751",
                InternalPartNumber = "IPN45577",
                Manufacturer = "FUJITSU",
                ManufacturerPartNumber = "FJJT234243",
                ManufacturerLotCode = "LOT2017080355",
                ManufactureDate = new DateTime(2017, 08, 3),
                Vendor = "Digikey",
                VendorPartNumber = "DIG543534537",
                ReceivedDate = new DateTime(2017, 9, 10),
                Status = MaterialStatus.Active,
                InitialQuantity = 500,
                Quantity = 151
            };

            m6 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566589856",
                InternalPartNumber = "IPN45577",
                Manufacturer = "FUJITSU",
                ManufacturerPartNumber = "FJJT234243",
                ManufacturerLotCode = "LOT2017080355",
                ManufactureDate = new DateTime(2017, 08, 3),
                Vendor = "Digikey",
                VendorPartNumber = "DIG543534537",
                ReceivedDate = new DateTime(2017, 9, 10),
                Status = MaterialStatus.Active,
                InitialQuantity = 500,
                Quantity = 151
            };

            m7 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4563453457",
                InternalPartNumber = "IPN45577",
                Manufacturer = "FUJITSU",
                ManufacturerPartNumber = "FJJT234243",
                ManufacturerLotCode = "LOT2017080355",
                ManufactureDate = new DateTime(2017, 08, 3),
                Vendor = "Digikey",
                VendorPartNumber = "DIG543534537",
                ReceivedDate = new DateTime(2017, 9, 10),
                Status = MaterialStatus.Active,
                InitialQuantity = 500,
                Quantity = 151
            };

            c1 = new MaterialCarrier()
            {
                UniqueIdentifier = "1233333",
            };

            c2 = new SMDTapeFeeder()
            {
                UniqueIdentifier = "1233334",
                BaseUniqueIdentifier = "123334",
                Name = "TAPEFEEDER8mm1233334",
                TapeWidth = 8,
                TapePitch = 8
            };

            c3 = new SMDTapeFeeder()
            {
                UniqueIdentifier = "1233335A",
                BaseUniqueIdentifier = "123335",
                Name = "TAPEFEEDER8mm1233335A",
                BaseName = "MULTILANEFEEDER123335",
                TapeWidth = 8,
                TapePitch = 4
            };

            t1 = new SMTHeadAndNozzle()
            {
                UniqueIdentifier = "UID234213421",
                Name = "Nozzle45",
                NozzleType = "409A",
                HeadId = "HEAD1",
                HeadNozzleNumber = 2
            };

            t2 = new SMTHeadAndNozzle()
            {
                UniqueIdentifier = "UID234223422",
                Name = "Nozzle47",
                NozzleType = "409A",
                HeadId = "HEAD2",
                HeadNozzleNumber = 3
            };

            t3 = new Tool()
            {
                UniqueIdentifier = "UID234228874",
                Name = "Hammer 45",
            };
        }

        public string GenerateInformationSystem()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new WorkOrdersCreated()
            {
                NewOrders = new List<WorkOrder>(new WorkOrder[] {new WorkOrder()
                {
                    WorkOrderIdentifier = new WorkOrderIdentifier()
                    {
                        WorkOrderId = "WO1122334455",
                    },
                    StartDate = new DateTime(2018, 9, 9, 0, 0, 0),
                    DateRequired = new DateTime(2018, 9, 15, 17, 0, 0),
                    Description = "Production Order for PCB Assembly",
                    PartNumber = "1122-3344",
                    PartRevision = "B",
                    LotNumber = "LOT4865",
                    Quantity = 220,
                    Status = WorkOrderStatus.AwaitingApproval,
                    Router = "PCB Assembly Process",
                    RouterRevision = "A",
                } })
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrdersUpdated()
            {
                UpdatedOrders = new List<WorkOrder>(new WorkOrder[] {new WorkOrder()
                {
                    WorkOrderIdentifier = new WorkOrderIdentifier()
                    {
                        WorkOrderId = "WO1122334455",
                    },
                    StartDate = new DateTime(2018, 9, 9, 0, 0, 0),
                    DateRequired = new DateTime(2018, 9, 15, 17, 0, 0),
                    Description = "Production Order for PCB Assembly",
                    PartNumber = "1122-5555",
                    PartRevision = "C",
                    LotNumber = "LOT4896",
                    Quantity = 220,
                    Status = WorkOrderStatus.AwaitingApproval,
                    Router = "PCB Assembly Process",
                    RouterRevision = "A",
                }})
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrderStatusUpdated()
            {
                WorkOrderIdentifier = new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO1122334455",
                },
                NewStatus = WorkOrderStatus.Scheduled,
                PreviousStatus = WorkOrderStatus.ApprovedAndPending
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrderQuantityUpdated()
            {
                WorkOrderIdentifier = new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO1122334455",
                },
                NewQuantity = 250,
                PreviousQuantity = 220
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrdersDeleted()
            {
                WorkOrderIdentifiers = new List<WorkOrderIdentifier>(new WorkOrderIdentifier[] {
                new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO1122334455",
                },
                new WorkOrderIdentifier()
                {
                    WorkOrderId = "WO9988776666",
                    Batch = "Batch1"
                }

                })
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrdersScheduled()
            {
                ScheduledWorkOrders = new List<ScheduledWorkOrder>(new ScheduledWorkOrder[] { new ScheduledWorkOrder()
                {
                    WorkOrderIdentifier = new WorkOrderIdentifier()
                    {
                        WorkOrderId = "WO1122334455"
                    },
                    WorkArea = "SMT Line 1",
                    Scheduler = new Operator()
                    {
                        ActorType = ActorType.Human,
                        FirstName = "John",
                        LastName = "Doe",
                        LoginName = "john.doe@domain1.com",
                        OperatorIdentifier = "BADGE4486"
                    },
                    StartTime = new DateTime(2018,8,2,11,0,0),
                    EndTime = new DateTime(2018,8,2,15,0,0),
                    ReservedResources = new List<string>(new string[] {"L1PRINTER1","L1PLACER1","L1PLACER2","L1OVEN1"}),
                    ReservedOperators = new List<Operator>(new Operator[] {op1}),
                    ReservedTools = new List<Tool>(new Tool []
                    {
                        new Tool()
                        {
                            UniqueIdentifier = "UID23890430",
                            Name = "TorqueWrench_123",
                        }
                    }),
                    ReservedMaterials = new List<MaterialPackage>(new MaterialPackage []
                    {
                        new MaterialPackage()
                        {
                            InternalPartNumber = "PN4452",
                            UniqueIdentifier = "UID23849854385",
                        },
                        new MaterialPackage()
                        {
                            InternalPartNumber = "PN4452",
                            UniqueIdentifier = "UID23849854386",
                        },
                        new MaterialPackage()
                        {
                            InternalPartNumber = "PN3358",
                            UniqueIdentifier = "UID23849854446",
                        }
                    })
                }})
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrdersUnscheduled()
            {
                ScheduledWorkOrderIdentifiers = new List<ScheduledWorkOrderIdentifier>(new ScheduledWorkOrderIdentifier[]
                {
                    new ScheduledWorkOrderIdentifier()
                    {
                        WorkOrderIdentifier = new WorkOrderIdentifier()
                        {
                            WorkOrderId = "WO1122334455"
                        },
                        WorkArea = "SMT Line 1",
                    }
                })
            };

            AppendMessage(msg, ref result);


            msg = new GetActiveFaultsRequest()
            {
                
            };
            AppendMessage(msg, ref result);

            msg = new GetActiveFaultsResponse()
            {
                ActiveFaults = new List<Fault>()
                {
                    new Fault()
                    {
                        Cause = FaultCause.MechanicalFailure,
                        Severity = FaultSeverity.Error,
                        FaultCode = "ERROR 3943480",
                        AccessType = AccessType.Remote,
                        OccurredAt = DateTime.Now,
                        Description = "PCB Transport is blocked",
                        DescriptionTranslations = new  Dictionary<string, string>()
                        {
                            { "de-DE", "Der Leiterplattentransport ist blockiert"}
                        },
                        DueDateTime = DateTime.Now.AddHours(3),
                        SideLocation = SideLocation.Right,
                        FaultOccurrenceId = Guid.NewGuid()
                    },
                    new Fault()
                    {
                        Cause = FaultCause.LoadError,
                        Severity = FaultSeverity.Error,
                        FaultCode = "ERROR 3943555",
                        AccessType = AccessType.Local,
                        OccurredAt = DateTime.Now,
                        Description = "PCB Transport is blocked",
                        DescriptionTranslations = new  Dictionary<string, string>()
                        {
                            { "de-DE", "Der Leiterplattentransport ist blockiert"}
                        },
                        DueDateTime = DateTime.Now.AddHours(3),
                        SideLocation = SideLocation.Right,
                        FaultOccurrenceId = Guid.NewGuid()
                }

                }
            };
            AppendMessage(msg, ref result);

            msg = new HandleFaultRequest()
            {
                FaultOccurrenceId = Guid.NewGuid(),
                HandleRemote = true
            };
            AppendMessage(msg, ref result);

            msg = new HandleFaultResponse()
            {
            };
            AppendMessage(msg, ref result);
            //*******************************//
            //*********New in CFX 1.3********//
            //*******************************//
            //NOTE: before copying the JSON in the documentation of the corresponding .cs
            //remember to change the & with the &amp; representation to avoid problems with the xml/html documentation
            msg = new CFX.Maintenance.GetResourceInformationRequest
            {
                CFXHandle = "SMT.SIPLACE_SX4.10000000"
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceInformationResponse()
            {
                ResourceInformation = new MaintenanceResource()
                {
                    UniqueIdentifier = "10000000",
                    SoftwareVersion = "713",
                    Vendor = "ASM",
                    ResourceType = "SMT",
                    ModelNumber = "SIPLACE SX4",
                    Name = "SMT SIPLACE SX 4",
                    SerialNumber = "UID1111111111111111",
                    Resources = new List<ResourceInformation>()
                    {
                        new Camera()
                        {
                            ResourceName = "SST34_1",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G1-GC__",
                            ResourcePosition = "1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_2",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G2-GC__",
                            ResourcePosition = "2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_3",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G3-GC__",
                            ResourcePosition = "2.3",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_4",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G4-GC__",
                            ResourcePosition = "1.4",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Conveyor() {
                            ResourceName = "Dual",
                            ResourceType = "Conveyor",
                            ResourceIdentifier = "10000000_Conveyor_0_E_1",
                            ResourcePosition = null,
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_1",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_1_R_1",
                            ResourcePosition = "1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_2",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_2_R_1",
                            ResourcePosition = "2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_3",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_2_L_1",
                            ResourcePosition = "2.3"
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_4",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_1_L_1",
                            ResourcePosition = "1.4",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new SMTNozzleChanger()
                        {
                            ResourceName = "NozzleCarrier_14_4.1",
                            ResourceType = "NozzleCarrier_14",
                            ResourceIdentifier = "10000000_NozzleChanger_1_L_1",
                            ResourcePosition = "1.4.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.Unkwnown
                        },
                        new SMTNozzleChanger()
                        {
                            ResourceName = "NozzleCarrier_10_3.1",
                            ResourceType = "NozzleCarrier_10_3",
                            ResourceIdentifier = "10000000_NozzleChanger_2_L_1",
                            ResourcePosition = "2.3.1.3",
                            IdentiferUniqueness = IdentiferUniquenessType.Unkwnown
                        },
                        new SMTHeadResource()
                        {
                            ResourceName = "C&P20_1",
                            ResourceType = "C&P20",
                            ResourceIdentifier = "00000000-00 000-H1-_____",
                            ResourcePosition = "1.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                            Cameras = new List<Camera>()
                            {
                                new Camera()
                                {
                                    ResourceName = "SST23_1.1",
                                    ResourceType = "SST23",
                                    ResourceIdentifier = "10000000-00 000-H1-HC__",
                                    ResourcePosition = "1.1.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                                }
                            },
                            RotationAxes = new List<RotationAxis>()
                            {
                                new RotationAxis()
                                {
                                    ResourceName = "C&P20_1_DpAxis1",
                                    ResourceType = null,
                                    ResourceIdentifier = "10000000-00 000-H1-DP1_",
                                    ResourcePosition = "1.1.1.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                                },
                                new RotationAxis()
                                 {
                                    ResourceName = "C&P20_1_DpAxis10",
                                    ResourceType = null,
                                    ResourceIdentifier = "10000000-00 000-H1-DP10",
                                    ResourcePosition = "1.1.1.10",
                                    IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                                }
                            },
                        },
                        new SMTHeadResource()
                        {
                            ResourceName = "C&P20_3",
                            ResourceType = "C&P20",
                            ResourceIdentifier = "00000000-00 000-H3-_____",
                            ResourcePosition = "2.3.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                            Cameras = new List<Camera>()
                            {
                                new Camera()
                                {
                                    ResourceName = "SST23_3.1",
                                    ResourceType = "SST23",
                                    ResourceIdentifier = "10000000-00 000-H3-HC__",
                                    ResourcePosition = "2.3.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                               }
                          },
                          RotationAxes = new List<RotationAxis>()
                          {
                              new RotationAxis()
                              {
                                  ResourceName = "C&P20_3_DpAxis1",
                                  ResourceType = null,
                                  ResourceIdentifier = "10000000-00 000-H3-DP1_",
                                  ResourcePosition = "2.3.1.1",
                                  IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                              },
                              new RotationAxis()
                              {
                                  ResourceName = "C&P20_3_DpAxis10",
                                  ResourceType = null,
                                  ResourceIdentifier = "10000000-00 000-H3-DP10",
                                  ResourcePosition = "2.3.1.10",
                                  IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                              }
                          }
                        },
                        new SMTTapeCutter()
                        {
                            ResourceName = "TapeCutter_1.4",
                            ResourceType = "",
                            ResourceIdentifier = "10000000_TapeCutter_1_L_1",
                            ResourcePosition = "1.0.4",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        },
                        new SMTTapeCutter()
                        {
                            ResourceName = "TapeCutter_1.1",
                            ResourceType = "",
                            ResourceIdentifier = "10000000_TapeCutter_1_R_1",
                            ResourcePosition = "1.0.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            //Event based ResourceInformation
            msg = new CFX.Maintenance.ResourceInformationEvent()
            {
                EventDateTime = new DateTime(DateTime.Now.Ticks - (DateTime.Now.Ticks % TimeSpan.TicksPerSecond),
                DateTime.Now.Kind),

                ResourceInformation = new MaintenanceResource()
                {
                    UniqueIdentifier = "10000000",
                    SoftwareVersion = "713",
                    Vendor = "ASM",
                    ResourceType = "SMT",
                    ModelNumber = "SIPLACE SX4",
                    Name = "SMT SIPLACE SX 4",
                    SerialNumber = "UID1111111111111111",
                    Resources = new List<ResourceInformation>()
                    {
                        new Camera()
                        {
                            ResourceName = "SST34_1",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G1-GC__",
                            ResourcePosition = "1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_2",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G2-GC__",
                            ResourcePosition = "2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_3",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G3-GC__",
                            ResourcePosition = "2.3",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Camera()
                        {
                            ResourceName = "SST34_4",
                            ResourceType = "SST34",
                            ResourceIdentifier = "10000000-00 000-G4-GC__",
                            ResourcePosition = "1.4",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Conveyor() {
                            ResourceName = "Dual",
                            ResourceType = "Conveyor",
                            ResourceIdentifier = "10000000_Conveyor_0_E_1",
                            ResourcePosition = null,
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_1",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_1_R_1",
                            ResourcePosition = "1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_2",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_2_R_1",
                            ResourcePosition = "2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_3",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_2_L_1",
                            ResourcePosition = "2.3"
                        },
                        new Gantry()
                        {
                            ResourceName = "Gantry_4",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_Gantry_X_1_L_1",
                            ResourcePosition = "1.4",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                        },
                        new SMTNozzleChanger()
                        {
                            ResourceName = "NozzleCarrier_14_4.1",
                            ResourceType = "NozzleCarrier_14",
                            ResourceIdentifier = "10000000_NozzleChanger_1_L_1",
                            ResourcePosition = "1.4.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.Unkwnown
                        },
                        new SMTNozzleChanger()
                        {
                            ResourceName = "NozzleCarrier_10_3.1",
                            ResourceType = "NozzleCarrier_10_3",
                            ResourceIdentifier = "10000000_NozzleChanger_2_L_1",
                            ResourcePosition = "2.3.1.3",
                            IdentiferUniqueness = IdentiferUniquenessType.Unkwnown
                        },
                        new SMTHeadResource()
                        {
                            ResourceName = "C&P20_1",
                            ResourceType = "C&P20",
                            ResourceIdentifier = "00000000-00 000-H1-_____",
                            ResourcePosition = "1.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                            Cameras = new List<Camera>()
                            {
                                new Camera()
                                {
                                    ResourceName = "SST23_1.1",
                                    ResourceType = "SST23",
                                    ResourceIdentifier = "10000000-00 000-H1-HC__",
                                    ResourcePosition = "1.1.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                                }
                            },
                            RotationAxes = new List<RotationAxis>()
                            {
                                new RotationAxis()
                                {
                                    ResourceName = "C&P20_1_DpAxis1",
                                    ResourceType = null,
                                    ResourceIdentifier = "10000000-00 000-H1-DP1_",
                                    ResourcePosition = "1.1.1.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                                },
                                new RotationAxis()
                                 {
                                    ResourceName = "C&P20_1_DpAxis10",
                                    ResourceType = null,
                                    ResourceIdentifier = "10000000-00 000-H1-DP10",
                                    ResourcePosition = "1.1.1.10",
                                    IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                                }
                            },
                        },
                        new SMTHeadResource()
                        {
                            ResourceName = "C&P20_3",
                            ResourceType = "C&P20",
                            ResourceIdentifier = "00000000-00 000-H3-_____",
                            ResourcePosition = "2.3.1",
                            IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                            Cameras = new List<Camera>()
                            {
                                new Camera()
                                {
                                    ResourceName = "SST23_3.1",
                                    ResourceType = "SST23",
                                    ResourceIdentifier = "10000000-00 000-H3-HC__",
                                    ResourcePosition = "2.3.1",
                                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent
                               }
                          },
                          RotationAxes = new List<RotationAxis>()
                          {
                              new RotationAxis()
                              {
                                  ResourceName = "C&P20_3_DpAxis1",
                                  ResourceType = null,
                                  ResourceIdentifier = "10000000-00 000-H3-DP1_",
                                  ResourcePosition = "2.3.1.1",
                                  IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                              },
                              new RotationAxis()
                              {
                                  ResourceName = "C&P20_3_DpAxis10",
                                  ResourceType = null,
                                  ResourceIdentifier = "10000000-00 000-H3-DP10",
                                  ResourcePosition = "2.3.1.10",
                                  IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                              }
                          }
                        },
                        new SMTTapeCutter()
                        {
                            ResourceName = "TapeCutter_1.4",
                            ResourceType = "",
                            ResourceIdentifier = "10000000_TapeCutter_1_L_1",
                            ResourcePosition = "1.0.4",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        },
                        new SMTTapeCutter()
                        {
                            ResourceName = "TapeCutter_1.1",
                            ResourceType = "",
                            ResourceIdentifier = "10000000_TapeCutter_1_R_1",
                            ResourcePosition = "1.0.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceSetupRequest()
            {
                CFXHandle = "SMT.SIPLACE_SX4.10000000"
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceSetupResponse()
            {
                ResourceSetup = new SMTPlacementSetup()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                    Feeders = new List<ResourceInformation>()
                    {
                       new SMTTapeFeederInformation()
                       {
                           ResourceIdentifier = "08ASMS500240",
                           ResourceName = "8mm-X Tape_2.40",
                           ResourcePosition ="2.40",
                           ResourceType = "8mm-X Tape",
                           MultiLanes = new List<MultiLane>()
                           {
                               new MultiLane()
                               {
                                   LaneNumber = 1,
                                   UniqueIdentifier = "08ASMS500240_1"
                               }
                           }
                       },
                       new SMTTapeFeederInformation()
                       {
                           ResourceIdentifier = "09ASMS500302",
                           ResourceName = "2x8mm-X Tape_3.2",
                           ResourcePosition ="3.2",
                           ResourceType = "2x8mm-X Tape",
                           MultiLanes = new List<MultiLane>()
                           {
                               new MultiLane()
                               {
                                   LaneNumber = 1,
                                   UniqueIdentifier = "09ASMS500302_Lane_1"
                               },
                               new MultiLane()
                               {
                                   LaneNumber = 2,
                                   UniqueIdentifier = "09ASMS500302_Lane_2"
                               }
                           }
                       }
                    },
                    NozzleChangerPockets = new List<SMTNozzleChangerPocket>()
                    {
                        new SMTNozzleChangerPocket()
                        {
                            ResourceName = "10000000_NozzleChanger_1_L_1_1_2_2_1006",
                            ResourceType = "1006",
                            ResourceIdentifier = "10000000_466",
                            ResourcePosition = "4.1.2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                        new SMTNozzleChangerPocket()
                        {
                            ResourceName = "10000000_NozzleChanger_1_L_1_1_2_1_1006",
                            ResourceType = "1006",
                            ResourceIdentifier = "10000000_467",
                            ResourcePosition = "4.1.2.1",
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                    },
                    Tables = new List<SMTTable>()
                    {
                        new SMTTable()
                        {
                            ResourceName = "Table_4",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_FeederDevice_1_L",
                            ResourcePosition = "4.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        },
                        new SMTTable()
                        {
                            ResourceName = "Table_1",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_FeederDevice_1_R",
                            ResourcePosition = "1.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            //CFX 1.3 Proposal to extend SPI / Inspection messages
            //New GetRecipeResponse example (UnitsInspectionRecipe)
            msg = new GetRecipeResponse()
            {
                Recipe = new SolderPasteInspectionRecipe()
                {
                    RecipeGenerationDate = DateTime.Now,
                    Name = "SolderRecipeXYZ_TextBoard1",
                    Revision = "1.3.3.33",

                    UnitsToInspect = new List<UnitToInspect>()
                    {
                        new UnitToInspect()
                        {
                            UnitPositionNumber = 1,
                            ChildObjects = new List<InspectionItem>()
                            {
                                new InspectionItem()
                                {
                                    RefNo = 1,
                                    CRD = "R100.1",
                                    PartNumber = "A2C000628080001",
                                    PackageType = "0201",
                                    Type = InspectionItemType.Pad,
                                    Group = "Resistor",

                                    Steps = new List<InspectionStep>()
                                    {
                                        new InspectionStep()
                                        {
                                            Sequence = 1,
                                            Name = "PasteDeposit",
                                            TargetValue = new InspectionMeasurementExpected()
                                            {
                                                    PX = 1000,
                                                    PY = 1200,
                                                    EX = 0.8,
                                                    EY = 1.5,
                                                    EZ = 0.1,
                                                    EA = 1.2,
                                                    EVol = 0.0001,
                                                    AR = 1.8,
                                                    RXY = 0
                                            }
                                        }
                                    }
                                },
                                new InspectionItem
                                {
                                    RefNo = 2,
                                    CRD = "R100.2",
                                    PartNumber = "A2C000628080001",
                                    PackageType = "0201",
                                    Type = InspectionItemType.Pad,
                                    Group = "Resistor",

                                    Steps = new List<InspectionStep>
                                    {
                                        new InspectionStep
                                        {
                                            Sequence = 1,
                                            Name = "PasteDeposit",
                                            TargetValue = new InspectionMeasurementExpected()
                                            {
                                               
                                                    PX = 3000,
                                                    PY = 1200,
                                                    EX = 0.8,
                                                    EY = 1.5,
                                                    EA = 1.2,
                                                    EVol = 0.0001,
                                                    AR = 1.8,
                                                    RXY = 0
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);
            //Event based ResourceSetup
            msg = new CFX.Maintenance.ResourceSetupEvent()
            {
                EventDateTime = new DateTime(DateTime.Now.Ticks - (DateTime.Now.Ticks % TimeSpan.TicksPerSecond),
                DateTime.Now.Kind),
                ResourceSetup = new SMTPlacementSetup()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                    Feeders = new List<ResourceInformation>()
                    {
                       new SMTTapeFeederInformation()
                       {
                           ResourceIdentifier = "08ASMS500240",
                           ResourceName = "8mm-X Tape_2.40",
                           ResourcePosition ="2.40",
                           ResourceType = "8mm-X Tape",
                           MultiLanes = new List<MultiLane>()
                           {
                               new MultiLane()
                               {
                                   LaneNumber = 1,
                                   UniqueIdentifier = "08ASMS500240_1"
                               }
                           }
                       },
                       new SMTTapeFeederInformation()
                       {
                           ResourceIdentifier = "09ASMS500302",
                           ResourceName = "2x8mm-X Tape_3.2",
                           ResourcePosition ="3.2",
                           ResourceType = "2x8mm-X Tape",
                           MultiLanes = new List<MultiLane>()
                           {
                               new MultiLane()
                               {
                                   LaneNumber = 1,
                                   UniqueIdentifier = "09ASMS500302_Lane_1"
                               },
                               new MultiLane()
                               {
                                   LaneNumber = 2,
                                   UniqueIdentifier = "09ASMS500302_Lane_2"
                               }
                           }
                       }
                    },
                    NozzleChangerPockets = new List<SMTNozzleChangerPocket>()
                    {
                        new SMTNozzleChangerPocket()
                        {
                            ResourceName = "10000000_NozzleChanger_1_L_1_1_2_2_1006",
                            ResourceType = "1006",
                            ResourceIdentifier = "10000000_466",
                            ResourcePosition = "4.1.2.2",
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                        new SMTNozzleChangerPocket()
                        {
                            ResourceName = "10000000_NozzleChanger_1_L_1_1_2_1_1006",
                            ResourceType = "1006",
                            ResourceIdentifier = "10000000_467",
                            ResourcePosition = "4.1.2.1",
                            IdentiferUniqueness = IdentiferUniquenessType.LocallyPersistent
                        },
                    },
                    Tables = new List<SMTTable>()
                    {
                        new SMTTable()
                        {
                            ResourceName = "Table_4",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_FeederDevice_1_L",
                            ResourcePosition = "4.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        },
                        new SMTTable()
                        {
                            ResourceName = "Table_1",
                            ResourceType = null,
                            ResourceIdentifier = "10000000_FeederDevice_1_R",
                            ResourcePosition = "1.1.1",
                            IdentiferUniqueness = IdentiferUniquenessType.UnserializedLocation
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceMaintenanceAndServiceRequest()
            {
                CFXHandle = "SMT.SIPLACE_SX4.10000000"
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceMaintenanceAndServiceResponse()
            {
                Machine = new Resource()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                },
                MachineServiceAndMaintenanceData = new List<ServiceAndMaintenanceData>()
                {
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "00000000-00 000-H2-_____",
                        Name = "C&P20_2",
                        CalibrationDetails = new List<Calibration>()
                        {
                            new Calibration()
                            {
                                CalibrationCode = "SegmentOffset",
                                CalibrationType = CalibrationType.SegmentOffset,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Ok,
                                Comments = ""
                            },
                            new Calibration()
                            {
                                CalibrationCode = "HeadMapping_0_R",
                                CalibrationType = CalibrationType.HeadMapping,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Failed,
                                Comments = "Calibration failed. Check log"
                            }
                        },
                        MaintenanceDetails = new List<MaintenanceInformation>()
                        {
                            new MaintenanceInformation()
                            {
                                Name = "HeadCompleteMileage",
                                CounterType = CounterType.Odometer,
                                CurrentCounterValue = 0.0,
                                CurrentRatio = 97.9,
                                CurrentRatioValid = true,
                                CurrentTimeStamp = DateTime.Now,
                                LastMaintenanceCounterValue=102,
                                LastMaintenanceTimeStamp = DateTime.Now.AddMonths(-1),
                                LastMaintenanceValid = false,
                                MeasurementLocation = "1.1.1"
                            }
                        },
                        SensorDetails = new List<SensorInformation>()
                        {
                            new SensorInformation()
                            {
                                ResourceIdentifier = null,
                                ResourceName = "Temperature sensor",
                                ResourcePosition = "2_R",
                                ResourceType = "Sensor",
                                Type = SensorType.Temperature,
                                Value = 19.2,
                                LowLimit = 15.0,
                                HighLimit = 30,
                                UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius,
                                SampleTime = DateTime.Now,
                            }
                        }
                    },
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "10000000-00 000-G1-GC__",
                        Name = "SST34_1",
                        CalibrationDetails = new List<Calibration>()
                        {
                            new Calibration()
                            {
                                CalibrationCode = "C123456",
                                CalibrationType = CalibrationType.BoardCamera,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Ok,
                                Comments = "Done ok"
                            }
                        },
                        VerificationDetails = new List<VerificationInformation>()
                        {
                            new VerificationInformation()
                            {
                                Type = VerificationType.Special,
                                Status = OperationStatus.Ok,
                                IsValid = true,
                                VerificationLocation = "1.2",
                                Name = "FCCSCalibration",
                                Value = 0.0,
                                LastExecution = DateTime.Now
                            },
                            new VerificationInformation()
                            {
                                Type = VerificationType.General,
                                Status = OperationStatus.Failed,
                                IsValid = true,
                                VerificationLocation = "2.3",
                                Name = "FCCSCleaningRequired",
                                Value = 0.0,
                                LastExecution = DateTime.Now
                            }
                        }
                    },
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "08ASMS500240",
                        Name = "8mm-X Tape_2.40",
                        MaintenanceDetails = new List<MaintenanceInformation>()
                        {
                            new MaintenanceInformation()
                            {
                                Name = "FeederCycleCount",
                                CounterType = CounterType.ActivityCount,
                                CurrentCounterValue = 57002,
                                CurrentRatio = 31.2,
                                CurrentRatioValid = true,
                                CurrentTimeStamp = DateTime.Now,
                                LastMaintenanceCounterValue = 23456,
                                LastMaintenanceTimeStamp = DateTime.Now.AddMonths(-2),
                                LastMaintenanceValid = false,
                                MeasurementLocation = "08ASMS500240_Lane_1"
                            }
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            //CFX 1.3 New example for UnitsInspected based on new InspectionMeasurementLean
            msg = new UnitsInspected()
            {
                RecipeName = "SolderRecipeXYZ_TextBoard1",
                RecipeRevision = "1.3.3.33",
                InspectedUnits = new List<InspectedUnit>()
                {
                    new InspectedUnit()
                    {
                        UnitIdentifier = "FFSHkkskamJDHS",
                        UnitPositionNumber = 1,
                        Inspections = new List<Inspection>()
                        {
                            new Inspection()
                            {
                                UniqueIdentifier = "11122344567",
                                RefNo = 1,
                                Measurements = new List<Measurement>()
                               {
                                    new InspectionMeasurementLean()
                                    {
                                        Sequence = 1,
                                        X = 0.76,
                                        Y = 1.53,
                                        DX = 0.035,
                                        DY = 0.009,
                                        Z = 0.086,
                                        A = 1.234,
                                        Vol = 0.000078,
                                    }
                                }
                            },
                            new Inspection()
                            {
                                UniqueIdentifier = "11122344568",
                                RefNo = 2,
                                Measurements = new List<Measurement>()
                                {
                                    new InspectionMeasurementLean()
                                    {
                                        Sequence = 1,
                                        X = 0.78,
                                        Y = 1.48,
                                        DX = 0.039,
                                        DY = 0.017,
                                        Z = 0.092,
                                        A = 1.226,
                                        Vol = 0.000074,
                                    }
                                }
                            }

                        }
                    }
                }
            };

            //Event based MaintenanceAndService
            msg = new CFX.Maintenance.ResourceMaintenanceAndServiceEvent()
            {
                EventDateTime = new DateTime(DateTime.Now.Ticks - (DateTime.Now.Ticks % TimeSpan.TicksPerSecond),
                DateTime.Now.Kind),
                Machine = new Resource()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                },
                MachineServiceAndMaintenanceData = new List<ServiceAndMaintenanceData>()
                {
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "00000000-00 000-H2-_____",
                        Name = "C&P20_2",
                        CalibrationDetails = new List<Calibration>()
                        {
                            new Calibration()
                            {
                                CalibrationCode = "SegmentOffset",
                                CalibrationType = CalibrationType.SegmentOffset,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Ok,
                                Comments = ""
                            },
                            new Calibration()
                            {
                                CalibrationCode = "HeadMapping_0_R",
                                CalibrationType = CalibrationType.HeadMapping,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Failed,
                                Comments = "Calibration failed. Check log"
                            }
                        },
                        MaintenanceDetails = new List<MaintenanceInformation>()
                        {
                            new MaintenanceInformation()
                            {
                                Name = "HeadCompleteMileage",
                                CounterType = CounterType.Odometer,
                                CurrentCounterValue = 0.0,
                                CurrentRatio = 97.9,
                                CurrentRatioValid = true,
                                CurrentTimeStamp = DateTime.Now,
                                LastMaintenanceCounterValue=102,
                                LastMaintenanceTimeStamp = DateTime.Now.AddMonths(-1),
                                LastMaintenanceValid = false,
                                MeasurementLocation = "1.1.1"
                            }
                        },
                        SensorDetails = new List<SensorInformation>()
                        {
                            new SensorInformation()
                            {
                                ResourceIdentifier = null,
                                ResourceName = "Temperature sensor",
                                ResourcePosition = "2_R",
                                ResourceType = "Sensor",
                                Type = SensorType.Temperature,
                                Value = 19.2,
                                LowLimit = 15.0,
                                HighLimit = 30,
                                UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius,
                                SampleTime = DateTime.Now,
                            }
                        }
                    },
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "10000000-00 000-G1-GC__",
                        Name = "SST34_1",
                        CalibrationDetails = new List<Calibration>()
                        {
                            new Calibration()
                            {
                                CalibrationCode = "C123456",
                                CalibrationType = CalibrationType.BoardCamera,
                                CalibrationTime =  DateTime.Now,
                                Status = OperationStatus.Ok,
                                Comments = "Done ok"
                            }
                        },
                        VerificationDetails = new List<VerificationInformation>()
                        {
                            new VerificationInformation()
                            {
                                Type = VerificationType.Special,
                                Status = OperationStatus.Ok,
                                IsValid = true,
                                VerificationLocation = "1.2",
                                Name = "FCCSCalibration",
                                Value = 0.0,
                                LastExecution = DateTime.Now
                            },
                            new VerificationInformation()
                            {
                                Type = VerificationType.General,
                                Status = OperationStatus.Failed,
                                IsValid = true,
                                VerificationLocation = "2.3",
                                Name = "FCCSCleaningRequired",
                                Value = 0.0,
                                LastExecution = DateTime.Now
                            }
                        }
                    },
                    new ServiceAndMaintenanceData()
                    {
                        UniqueIdentifier = "08ASMS500240",
                        Name = "8mm-X Tape_2.40",
                        MaintenanceDetails = new List<MaintenanceInformation>()
                        {
                            new MaintenanceInformation()
                            {
                                Name = "FeederCycleCount",
                                CounterType = CounterType.ActivityCount,
                                CurrentCounterValue = 57002,
                                CurrentRatio = 31.2,
                                CurrentRatioValid = true,
                                CurrentTimeStamp = DateTime.Now,
                                LastMaintenanceCounterValue = 23456,
                                LastMaintenanceTimeStamp = DateTime.Now.AddMonths(-2),
                                LastMaintenanceValid = false,
                                MeasurementLocation = "08ASMS500240_Lane_1"
                            }
                        }
                    }
                }
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceMaintenanceStatusRequest()
            {
               Machine = new Resource()
               {
                   UniqueIdentifier = "10000000",
                   Name = "SIPLACE SX4",
               },
              ResourceMaintenanceDetails = new List<ResourceInformation>()
              {
                  new SMTTapeFeederInformation()
                  {
                    ResourceIdentifier = "08FAUT901183",
                    ResourceType = "8mm-X Tape",
                    ResourcePosition = "2.14",
                    ResourceName = "8mm-X Tape_2.14",
                  }
              }
            };
            AppendMessage(msg, ref result);

            msg = new CFX.Maintenance.GetResourceMaintenanceStatusResponse()
            {
                Machine = new Resource()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                    ResourceType = "SMT"
                },
                ResourceMaintenanceDetails = new List<ResourceInformation>()
              {
                  new SMTTapeFeederInformation()
                  {
                    ResourceIdentifier = "08FAUT901183",
                    ResourceType = "8mm-X Tape",
                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                    ResourcePosition = "2.14",
                    ResourceName = "8mm-X Tape_2.14",
                    MaintenanceStatus = new MaintenanceStatus()
                    {
                        Reason = "No reason",
                        ResultState = MaintenanceState.Ok
                    },
                    MultiLanes = new List<MultiLane>()
                    {
                        new MultiLane()
                        {
                            LaneNumber = 1,
                            UniqueIdentifier = "09ASMS500302_Lane_1",
                            CycleCount = 1002
                        },
                        new MultiLane()
                        {
                            LaneNumber = 2,
                            UniqueIdentifier = "09ASMS500302_Lane_2",
                            CycleCount = 3451
                        }
                    },
                  }
              }
            };
            AppendMessage(msg, ref result);

            //Event based MaintenanceStatus
            msg = new CFX.Maintenance.ResourceMaintenanceStatusEvent()
            {
                EventDateTime = new DateTime(DateTime.Now.Ticks - (DateTime.Now.Ticks % TimeSpan.TicksPerSecond),
                DateTime.Now.Kind),
                Machine = new Resource()
                {
                    UniqueIdentifier = "10000000",
                    Name = "SIPLACE SX4",
                    ResourceType = "SMT",
                    FirmwareVersion = "0",
                    ModelNumber = "1234",
                    SerialNumber = "1234567890",
                    SoftwareVersion = "730",
                    Vendor = "ASM"
                },
                ResourceMaintenanceDetails = new List<ResourceInformation>()
              {
                  new SMTTapeFeederInformation()
                  {
                    ResourceIdentifier = "08FAUT901183",
                    ResourceType = "8mm-X Tape",
                    ResourcePosition = "2.14",
                    ResourceName = "8mm-X Tape_2.14",
                    IdentiferUniqueness = IdentiferUniquenessType.GloballyPersistent,
                    MaintenanceStatus = new MaintenanceStatus()
                    {
                        Reason = "No reason",
                        ResultState = MaintenanceState.Ok
                    },
                    MultiLanes = new List<MultiLane>()
                    {
                        new MultiLane()
                        {
                            LaneNumber = 1,
                            UniqueIdentifier = "09ASMS500302_Lane_1",
                            CycleCount = 1002
                        },
                        new MultiLane()
                        {
                            LaneNumber = 2,
                            UniqueIdentifier = "09ASMS500302_Lane_2",
                            CycleCount = 3451
                        }
                    },
                  }
              }
            };
            AppendMessage(msg, ref result);
            //******************************//
            //New CFX 1.3 Proposal for Hermes Magazine management
            msg = new GetMagazineDataRequest()
            {
                MagazineId = "ID12345"
            };
            AppendMessage(msg, ref result);

            //New CFX 1.3 Proposal for Hermes Magazine management
            msg = new GetMagazineDataRequest()
            {
                MagazineId = "ID12345"
            };
            AppendMessage(msg, ref result);

            msg = new GetMagazineDataResponse()
            {
               Result = new RequestResult()
               {
                   
               },
               MagazineData = new Magazine()
               {
                   MagazineId = "ID12345",
                   HermesUnits = new List<HermesUnit>()
                   {
                       new HermesUnit()
                       {
                           BoardId =Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500001",
                           TopBarcode = "BT_M20206500001",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 1,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       },
                       new HermesUnit()
                       {
                           BoardId = Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500002",
                           TopBarcode = "BT_M20206500002",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 2,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       }
                   }
               }
            };
            AppendMessage(msg, ref result);

            msg = new MagazineArrived()
            {
                MagazineData = new Magazine()
                {
                    MagazineId = "ID12345",
                    HermesUnits = new List<HermesUnit>()
                    {
                       new HermesUnit()
                       {
                           BoardId = Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500001",
                           TopBarcode = "BT_M20206500001",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 1,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       },
                       new HermesUnit()
                       {
                           BoardId = Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500002",
                           TopBarcode = "BT_M20206500002",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 2,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       }
                   }
                }
            };
            AppendMessage(msg, ref result);
            
            msg = new MagazineDeparted()
            {
                MagazineData = new Magazine()
                {
                    MagazineId = "ID12345",
                    HermesUnits = new List<HermesUnit>()
                    {
                       new HermesUnit()
                       {
                           BoardId = Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500001",
                           TopBarcode = "BT_M20206500001",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 1,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       },
                       new HermesUnit()
                       {
                           BoardId = Guid.NewGuid().ToString(),
                           BoardIdCreatedBy = "Printer12345",
                           BottomBarcode = "B_M20206500002",
                           TopBarcode = "BT_M20206500002",
                           BottomClearanceHeight = 1.2,
                           ConveyorSpeed = 1200,
                           Lenght = 160,
                           SlotId = 2,
                           TopClearanceHeight = 2.5,
                           Width = 100,
                           Thickness = 10,
                           Weight = 80,
                           FailedBoard = 1,
                           FlippedBoard = 1,
                           ProductTypeId = "Product_A",
                           WorkOrderIdentifier = new WorkOrderIdentifier()
                           {
                                WorkOrderId = "WO9988776666",
                                Batch = "Batch1"
                           }
                       }
                   }
                }

            };
            AppendMessage(msg, ref result);
            return result;
        }
    }
}
