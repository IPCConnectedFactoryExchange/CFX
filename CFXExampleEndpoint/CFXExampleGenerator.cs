using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using CFX.Production;
using CFX.Production.Assembly;
using CFX.InformationSystem.UnitValidation;
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
            result += GenerateResourcePerformance();
            //result += GenerateProduction();
            result += GenerateAssembly();
            //result += GenerateMaterials();
            return result;
        }

        private MaterialPackageDetail m1, m2, m3, m4, m5, m6, m7;
        private MaterialCarrier c1, c2, c3;

        public string GenerateAssembly()
        {
            string result = "";
            CFXMessage msg = null;

            msg = new MaterialsInstalled()
            {
                InstalledMaterials = new List<InstalledMaterial>(new InstalledMaterial[]
                {
                    new InstalledMaterial()
                    {
                        UnitIdentifier = "PANEL23423432",
                        UnitPosition = 1,
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
                        UnitPosition = 2,
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

            msg = new CFX.ResourcePerformance.FaultOccurred()
            {
                Fault = flt
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
                CurrentPower = 122.6,
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

            msg = new CFX.ResourcePerformance.SMTPlacement.FaultOccurred()
            {
                Fault = smtFlt
            };
            AppendMessage(msg, ref result);

            msg = new ToolChanged()
            {
                OldNozzle = null,
                ReturnedToHolder = null,
                NewNozzle = new SMTNozzle()
                {
                    UniqueIdentifier = "UID23890430",
                    Name = "NOZZLE234324",
                    NozzleType = "TYPE914",
                    HeadId = "HEAD1",
                    HeadNozzleNumber = 1
                },
                LoadedFromHolder = new SMTNozzleHolder()
                {
                    LocationUniqueIdentifier = "UID238943243243",
                    LocationName = "HOLDER14",
                    BaseName = "NEST2"
                }
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

            msg = new CFX.ResourcePerformance.THTInsertion.FaultOccurred()
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

            msg = new StencilChanged()
            {
                OldStencil = new SMTStencil()
                {
                    UniqueIdentifier = "UID23432434",
                    Name = "STENCIL234343"
                },
                NewStencil = new SMTStencil()
                {
                    UniqueIdentifier = "UID234344455",
                    Name = "STENCIL8784322"
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

            msg = new SqueegeeChanged()
            {
                OldSqueegee = new SMTSqueegee()
                {
                    UniqueIdentifier = "UID23432434",
                    Name = "STENCIL234343"
                },
                NewSqueegee = new SMTSqueegee()
                {
                    UniqueIdentifier = "UID234344455",
                    Name = "STENCIL8784322"
                }
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
                 MaterialPackageIdentifiers = new List<string>(new string []
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
                Materials = new List<MaterialPackageDetail>(new MaterialPackageDetail []
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
                OriginalMaterialPackage = m6.ToMaterialPackage(),
                NewMaterialPackage = m7.ToMaterialPackage()
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

            msg = new MaterialTransportStarted()
            {
                TransportOrderNumber = "TR329483249830000",
                FinalDestination = "LINE1",
                NextCheckpoint = "SMT STAGING AREA 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                StartedBy = o1
            };
            AppendMessage(msg, ref result);

            msg = new CheckpointReached()
            {
                TransportOrderNumber = "TR329483249830000",
                Checkpoint = "SMT STAGING AREA 1",
                FinalDestination = "LINE 1",
                NextCheckpoint = "LINE 1",
                RelatedWorkOrderNumber = "WO2384702937403280032",
                TrackedBy = o2
            };
            AppendMessage(msg, ref result);

            msg = new MaterialTransportCompleted()
            {
                TransportOrderNumber = "TR329483249830000",
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
                Lane="1",
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

            msg = new LockLaneRequest()
            {
                Lane = "1",
                Reason = LockReason.QualityIssue,
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

            msg = new LockLaneResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new LockStageRequest()
            {
                Stage = "STAGE1",
                Reason = LockReason.QualityIssue,
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

            msg = new LockStageResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new LockStationRequest()
            {
                Reason = LockReason.QualityIssue,
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
                                    ExpectedValue = "17.5", ExpectedValueUnits = "C", MaxumumAcceptableValue = "18.9", MinimumAcceptableValue = "11.5",
                                    Result = StatusResult.Success, TimeRecorded = DateTime.Now, UnitPositionNumber = 1,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "U22", PartNumber = "IPN11234" }
                                    }) },
                   new Reading() { ReadingIdentifier = "VOLTAGE1", ReadingSequence = 2, ValueDataType = DataType.Numeric, Value = "220.56", ValueUnits = "VDC",
                                    ExpectedValue = "221.50", ExpectedValueUnits = "VDC", MaxumumAcceptableValue = "223.0", MinimumAcceptableValue = "220.0",
                                    Result = StatusResult.Success, TimeRecorded = DateTime.Now, UnitPositionNumber = 1,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "R11", PartNumber = "IPN11222" },
                                        new ComponentDesignator() { ReferenceDesignator = "C12", PartNumber = "IPN11569" },
                                        new ComponentDesignator() { ReferenceDesignator = "R56", PartNumber = "IPN11222" }
                                    }) },
                   new Reading() { ReadingIdentifier = "CHIPTEMP1", ReadingSequence = 1, ValueDataType = DataType.Numeric, Value = "18.9", ValueUnits = "C",
                                    ExpectedValue = "17.5", ExpectedValueUnits = "C", MaxumumAcceptableValue = "18.9", MinimumAcceptableValue = "11.5",
                                    Result = StatusResult.Success, TimeRecorded = DateTime.Now, UnitPositionNumber = 2,
                                    Components = new List<ComponentDesignator>(new ComponentDesignator []
                                    {
                                        new ComponentDesignator() { ReferenceDesignator = "U22", PartNumber = "IPN11234" }
                                    }) },
                   new Reading() { ReadingIdentifier = "VOLTAGE1", ReadingSequence = 2, ValueDataType = DataType.Numeric, Value = "221.56", ValueUnits = "VDC",
                                    ExpectedValue = "221.50", ExpectedValueUnits = "VDC", MaxumumAcceptableValue = "223.0", MinimumAcceptableValue = "220.0",
                                    Result = StatusResult.Success, TimeRecorded = DateTime.Now, UnitPositionNumber = 2,
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
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 0.254, Y = 0.556, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 6.254, Y = 0.556, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnitsDeparted()
            {
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 0.254, Y = 0.556, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 6.254, Y = 0.556, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new UnlockLaneRequest()
            {
                Lane = "1",
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

            msg = new UnlockLaneResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
            };
            AppendMessage(msg, ref result);

            msg = new UnlockStageRequest()
            {
                Stage = "STAGE1",
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

            msg = new UnlockStageResponse()
            {
                Result = new RequestResult()
                {
                    Result = StatusResult.Success,
                    Message = "OK",
                    ResultCode = 0
                }
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
                Recipe  = new Recipe()
                {
                    Name = "RECIPE234324",
                    Revision = "C",
                    MimeType = "application/octet-stream",
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
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 0.254, Y = 0.556, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 6.254, Y = 0.556, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new ValidateUnitsRequest()
            {
                PrimaryIdentifier = "CARRIER2342",
                Validations = new List<ValidationType>(
                    new ValidationType []
                    {
                        ValidationType.UnitRouteValidation,
                        ValidationType.UnitStatusValidation
                    }),
                Units = new List<UnitPosition>(
                    new UnitPosition[]
                    {
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 0.254, Y = 0.556, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 6.254, Y = 0.556, Rotation = 90.0},
                    })
            };
            AppendMessage(msg, ref result);

            msg = new ValidateUnitsResponse()
            {
                PrimaryResult = new ValidationResult()
                {
                    Result = ValidationStatus.Passed,
                    Identifier = "CARRIER5566",
                    Message = "OK",
                    FailureCode = 0,
                },

                Results = new List<ValidationResult>(new ValidationResult[]
                {
                    new ValidationResult()
                    {
                        Result = ValidationStatus.Passed,
                        Identifier = "UNIT1123",
                        Message = "OK",
                        FailureCode = 0,
                    },
                    new ValidationResult()
                    {
                        Result = ValidationStatus.Passed,
                        Identifier = "UNIT1124",
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
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT1", UnitIdentifier = "CARRIER5566", X = 0.254, Y = 0.556, Rotation = 0},
                        new UnitPosition() { PositionNumber = 1, PositionName = "CIRCUIT2", UnitIdentifier = "CARRIER5566", X = 6.254, Y = 0.556, Rotation = 90.0},
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

            msg = new BlockMaterialLocationResponse()
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

            msg = new UnblockMaterialLocationResponse()
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
            data += msg.ToJson();
            data += "\r\n\r\n";
        }

        public void InitializeMaterials()
        {
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
        }

    }
}
