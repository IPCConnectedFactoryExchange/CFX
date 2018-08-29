using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.Structures;
using CFX.Structures.SMTPlacement;
using CFX.Structures.SolderPastePrinting;
using CFX.Structures.THTInsertion;
using CFX.Structures.SolderPasteInspection;
using CFX.Structures.PCBInspection;
using CFX.Production;
using CFX.Production.Assembly;
using CFX.Production.Application;
using CFX.Production.TestAndInspection;
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
                FullName = "Joseph Smith",
                LoginName = "joseph.smith@abcdrepairs.com",
                OperatorIdentifier = "UID235434324"
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

            System.IO.File.AppendAllText(@"y:\jjwcode\solderpastetest.txt", msg.ToJson(false));

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

            CFXMessage msg = new WhoIsThereRequest();
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
                    CFXHandle = "SMTPlus.Model_11111.SN444555",
                    RequestNetworkUri = "amqp://host55:5688/",
                    RequestTargetAddress = "/queue/SN444555",
                    UniqueIdentifier = "UID1111111111111111",
                    FriendlyName = "SMD Printer 444555",
                    Vendor = "SMT Plus",
                    ModelNumber = "Model_11111",
                    SerialNumber = "SN444555",
                    NumberOfLanes = 1,
                    NumberOfStages = 1,
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
                    NumberOfStages = 4,
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
                    Stages = new List<SMTStageInformation>(new SMTStageInformation[]
                    {
                        new SMTStageInformation()
                        {
                            StageName = "BUFFERSTAGE1",
                            NumberOfFeederStations = 0
                        },
                        new SMTStageInformation()
                        {
                            StageName = "WORKSTAGE1",
                            NumberOfFeederStations = 100
                        },
                        new SMTStageInformation()
                        {
                            StageName = "WORKSTAGE2",
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
                            HeadId = "HEAD1",
                            PlacementAccuracy = 0.001
                        },
                        new SMTHeadInformation()
                        {
                            HeadId = "HEAD2",
                            PlacementAccuracy = 0.001
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

            Fault flt = new Fault()
            {
                Cause = FaultCause.MechanicalFailure,
                Severity = FaultSeverity.Error,
                FaultCode = "ERROR 3943480",
            };

            msg = new StationStateChanged()
            {
                OldState = ResourceState.IdleStarved,
                OldStateDuration = TimeSpan.FromSeconds(85),
                NewState = ResourceState.ReadyProcessingActive
            };
            AppendMessage(msg, ref result);

            msg = new StationStateChanged()
            {
                OldState = ResourceState.ReadyProcessingExecuting,
                OldStateDuration = TimeSpan.FromSeconds(25),
                NewState = ResourceState.UnplannedDowntime,
                RelatedFault = flt
            };
            AppendMessage(msg, ref result);

            msg = new StageStateChanged()
            {
                Stage = "STAGE2",
                OldState = ResourceState.IdleStarved,
                OldStateDuration = TimeSpan.FromSeconds(85),
                NewState = ResourceState.ReadyProcessingActive
            };
            AppendMessage(msg, ref result);

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = flt
            };
            AppendMessage(msg, ref result);

            msg = new FaultCleared()
            {
                FaultOccurrenceId = flt.FaultOccurrenceId
            };
            AppendMessage(msg, ref result);

            msg = new StationOffline();
            AppendMessage(msg, ref result);

            msg = new StationOnline()
            {
                OfflineDuration = TimeSpan.FromMinutes(23)
            };
            AppendMessage(msg, ref result);

            msg = new ModifyStationParameterRequest()
            {
                ParameterName = "Torque1",
                ParameterValue = "35.6"
            };
            AppendMessage(msg, ref result);

            msg = new ModifyStationParameterResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    ResultCode = 0,
                    Message = "OK"
                },
                ParameterName = "Torque1",
                NewParameterValue = "35.6",
                OldParameterValue = "22.6"
            };
            AppendMessage(msg, ref result);

            msg = new StationParameterModified()
            {
                ParameterName = "Torque1",
                NewParameterValue = "35.6",
                OldParameterValue = "22.6"
            };
            AppendMessage(msg, ref result);

            msg = new LogEntryRecorded()
            {
                Importance = LogImportance.Information,
                Message = "Beam 1 Zeroed and Homed",
                InformationId = "INF21321321",
                Stage = "STAGE1",
                Lane = "1"
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
                            FullName = "Joseph Smith",
                            LoginName = "joseph.smith@abcdrepairs.com",
                            OperatorIdentifier = "UID235434324"
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
                            FullName = "Joseph Smith",
                            LoginName = "joseph.smith@abcdrepairs.com",
                            OperatorIdentifier = "UID235434324"
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
                Lane = "LANE1",
                Stage = "STAGE2",
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
                        Width = SMDTapeWidth.Tape8mm,
                        Pitch = SMDTapePitch.Pitch8mm,
                        LaneNumber = 1
                    }
                },
                Nozzle = new SMTNozzle()
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
                NewTool = new SMTNozzle()
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
                Lane = "LANE1",
                Stage = "STAGE2",
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
                        Width = SMDTapeWidth.Tape8mm,
                        Pitch = SMDTapePitch.Pitch8mm,
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Adjustable
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Adjustable
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Adjustable
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Adjustable
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
                    Message = "SETUP OK",
                    ResultCode = 0
                }
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
                                Width = SMDTapeWidth.Tape8mm,
                                Pitch = SMDTapePitch.Pitch8mm
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
                                Width = SMDTapeWidth.Tape8mm,
                                Pitch = SMDTapePitch.Pitch8mm
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Pitch8mm
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
                            Width = SMDTapeWidth.Tape8mm,
                            Pitch = SMDTapePitch.Pitch8mm
                        }
                    },
                })
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
                FullName = "Bill Smith",
                LoginName = "bill.smith@domain1.com",
                OperatorIdentifier = Guid.NewGuid().ToString()
            };

            Operator o2 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "John",
                LastName = "Doe",
                FullName = "John Doe",
                LoginName = "john.doe@domain1.com",
                OperatorIdentifier = Guid.NewGuid().ToString()
            };

            Operator o3 = new Operator()
            {
                ActorType = ActorType.Human,
                FirstName = "Mike",
                LastName = "Dolittle",
                FullName = "Mike Dolittle",
                LoginName = "mike.dolittle@domain1.com",
                OperatorIdentifier = Guid.NewGuid().ToString()
            };

            msg = new TransportOrderStarted()
            {
                TransportOrderNumber = "TR329483249830000",
                Status = TransportOrderStatus.Pending,
                Comments = "Initiating new transport order.  Waiting to be kitted.",
                FinalDestination = "LINE1",
                NextCheckpoint = "SMT STAGING AREA 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                StartedBy = o1
            };
            AppendMessage(msg, ref result);

            msg = new TransportOrderStatusChanged()
            {
                TransportOrderNumber = "TR329483249830000",
                Status = TransportOrderStatus.Kitting,
                Comments = "Kitting Underway...",
                FinalDestination = "LINE 1",
                NextCheckpoint = "SMT STAGING AREA 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                UpdatedBy = o1
            };
            AppendMessage(msg, ref result);

            msg = new CheckpointReached()
            {
                TransportOrderNumber = "TR329483249830000",
                Status = TransportOrderStatus.InTransit,
                Comments = "Arrived SMT Production Area",
                Checkpoint = "SMT STAGING AREA 1",
                FinalDestination = "LINE 1",
                NextCheckpoint = "LINE 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                TrackedBy = o2
            };
            AppendMessage(msg, ref result);

            msg = new TransportOrderCompleted()
            {
                TransportOrderNumber = "TR329483249830000",
                Comments = "Received at Line 1",
                FinalDestination = "LINE 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                AcceptedBy = o3
            };
            AppendMessage(msg, ref result);

            msg = new GetTransportOrderStatusRequest()
            {
                TransportOrderNumber = "TR329483249830000",
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
                TransportOrderNumber = "TR329483249830000",
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
                Stage = "1",
                Lane = "1",
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
                Stage = "1",
                Lane = "1",
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
                Stage = "1",
                Lane = "1"
            };
            AppendMessage(msg, ref result);

            GetRequiredSetupResponse grsr = new GetRequiredSetupResponse()
            {
                Stage = "1",
                Lane = "1",
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
                    Stage = "1",
                    Lane = "1",
                    SetupName = "COMMONSETUP45",
                }
            };
            grsr.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1123", Position = "B1.F.45" });
            grsr.SetupRequirements.MaterialSetupRequirements.Add(new MaterialSetupRequirement() { PartNumber = "IPN1124", Position = "B1.F.47" });
            grsr.SetupRequirements.MaterialSetupRequirements[0].ApprovedAlternateParts.AddRange(new string[] { "IPN2343", "IPN3432" });
            grsr.SetupRequirements.MaterialSetupRequirements[1].ApprovedAlternateParts.AddRange(new string[] { "IPN3344", "IPN3376" });
            grsr.SetupRequirements.MaterialSetupRequirements[0].ApprovedManufacturerParts.AddRange(new string[] { "MOT4329", "SAM5566" });
            grsr.SetupRequirements.MaterialSetupRequirements[1].ApprovedManufacturerParts.AddRange(new string[] { "JP55443", "TX554323" });
            AppendMessage(grsr, ref result);

            msg = new LockStationRequest()
            {
                Reason = LockReason.QualityIssue,
                Lane = "1",
                Stage = "5",
                Requestor = new Operator()
                {
                    ActorType = ActorType.Human,
                    FirstName = "Bill",
                    LastName = "Smith",
                    FullName = "Bill Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = Guid.NewGuid().ToString()
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
                    FullName = "Bill Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = Guid.NewGuid().ToString()
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
                    FullName = "Bill Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = Guid.NewGuid().ToString()
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

            msg = new RecipeActivated()
            {
                Lane = "1",
                RecipeName = "RECIPE3234",
                Revision = "B"
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
                    FullName = "Bill Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = Guid.NewGuid().ToString()
                },
                Reason = RecipeModificationReason.PositionalCorrection
            };
            AppendMessage(msg, ref result);

            msg = new SetupRequirementsChanged()
            {
                Lane = "1",
            };
            AppendMessage(msg, ref result);

            msg = new UnitsArrived()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsDeparted()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsDisqualified()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
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
                    FullName = "Bill Smith",
                    LoginName = "bill.smith@domain1.com",
                    OperatorIdentifier = Guid.NewGuid().ToString()
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
                Stage = "1"
            };
            AppendMessage(msg, ref result);

            msg = new WorkStagePaused()
            {
                TransactionID = transId,
                Stage = "1"
            };
            AppendMessage(msg, ref result);

            msg = new WorkStageResumed()
            {
                TransactionID = transId,
                Stage = "1"
            };
            AppendMessage(msg, ref result);

            msg = new WorkStageStarted()
            {
                TransactionID = transId,
                Stage = "1"
            };
            AppendMessage(msg, ref result);

            msg = new WorkStarted()
            {
                TransactionID = transId,
                Lane = "1",
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
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
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
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

                Results = new List<ValidationResult>(new ValidationResult[]
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
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 50.45, Y = 80.66, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new BlockMaterialLocationsRequest()
            {
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
                    Message = "BLOCKED OK",
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
                    Message = "BLOCKED OK",
                    ResultCode = 0
                }
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
                FullName = "Joseph Smith",
                LoginName = "joseph.smith@abcdrepairs.com",
                OperatorIdentifier = "UID235434324"
            };

            m1 = new MaterialPackageDetail()
            {
                UniqueIdentifier = "MAT4566556456",
                InternalPartNumber = "IPN47788",
                Manufacturer = "MOTOROLA",
                ManufacturerPartNumber = "MOT231234",
                ManufacuterLotCode = "LOT2016110588",
                ManufactureDate = new DateTime(2016, 11, 5),
                Vendor = "Digikey",
                VendorPartNumber = "DIG23452442",
                ReceivedDate = new DateTime(2017, 5, 6),
                Status = MaterialStatus.Active,
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
                ManufacuterLotCode = "LOT2016101008",
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
                ManufacuterLotCode = "LOT2017080355",
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
                ManufacuterLotCode = "LOT2017080355",
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
                ManufacuterLotCode = "LOT2017080355",
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
                ManufacuterLotCode = "LOT2017080355",
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
                ManufacuterLotCode = "LOT2017080355",
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
                Width = SMDTapeWidth.Tape8mm,
                Pitch = SMDTapePitch.Adjustable
            };

            c3 = new SMDTapeFeeder()
            {
                UniqueIdentifier = "1233335A",
                BaseUniqueIdentifier = "123335",
                Name = "TAPEFEEDER8mm1233335A",
                BaseName = "MULTILANEFEEDER123335",
                Width = SMDTapeWidth.Tape8mm,
                Pitch = SMDTapePitch.Adjustable
            };

            t1 = new SMTNozzle()
            {
                UniqueIdentifier = "UID234213421",
                Name = "Nozzle45",
                NozzleType = "409A",
                HeadId = "HEAD1",
                HeadNozzleNumber = 2
            };

            t2 = new SMTNozzle()
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
                        WorkOrderNumber = "WO1122334455",
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
                        WorkOrderNumber = "WO1122334455",
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
                    WorkOrderNumber = "WO1122334455",
                },
                NewStatus = WorkOrderStatus.Scheduled,
                PreviousStatus = WorkOrderStatus.ApprovedAndPending
            };

            AppendMessage(msg, ref result);

            msg = new WorkOrderQuantityUpdated()
            {
                WorkOrderIdentifier = new WorkOrderIdentifier()
                {
                    WorkOrderNumber = "WO1122334455",
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
                    WorkOrderNumber = "WO1122334455",
                },
                new WorkOrderIdentifier()
                {
                    WorkOrderNumber = "WO9988776666",
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
                        WorkOrderNumber = "WO1122334455"
                    },
                    WorkArea = "SMT Line 1",
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
                            WorkOrderNumber = "WO1122334455"
                        },
                        WorkArea = "SMT Line 1",
                    }
                })
            };

            AppendMessage(msg, ref result);

            return result;
        }
    }
}
