using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;
using CFX.Structures.Maintenance;

namespace CFX.Maintenance
{
    /// <summary>
    /// Allows any CFX endpoint to send the resource and sub-resources maintenance and services of a specified single endpoint. 
    /// The event can be sent "on change" or "time" base.
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "EventDateTime": "2020-11-16T14:50:03+01:00",
    ///   "Machine": {
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SIPLACE SX4",
    ///     "Vendor": null,
    ///     "ModelNumber": null,
    ///     "SerialNumber": null,
    ///     "SoftwareVersion": null,
    ///     "FirmwareVersion": null
    ///   },
    ///   "MachineServiceAndMaintenanceData": [
    ///     {
    ///       "UniqueIdentifier": "00000000-00 000-H2-_____",
    ///       "Name": "C&P20_2",
    ///       "CalibrationDetails": [
    ///         {
    ///           "CalibrationCode": "SegmentOffset",
    ///           "CalibrationType": "SegmentOffset",
    ///           "Comments": "",
    ///           "Status": "Ok",
    ///           "CalibrationTime": "2020-11-16T14:50:03.5513363+01:00"
    ///         },
    ///         {
    ///           "CalibrationCode": "HeadMapping_0_R",
    ///           "CalibrationType": "HeadMapping",
    ///           "Comments": "Calibration failed. Check log",
    ///           "Status": "Failed",
    ///           "CalibrationTime": "2020-11-16T14:50:03.5513363+01:00"
    ///         }
    ///       ],
    ///       "ErrorDetails": null,
    ///       "MaintenanceDetails": [
    ///         {
    ///           "Name": "HeadCompleteMileage",
    ///           "CounterType": "Odometer",
    ///           "CustomCounterType": null,
    ///           "MeasurementLocation": "1.1.1",
    ///           "CurrentCounterValue": 0.0,
    ///           "CurrentRatio": 97.9,
    ///           "CurrentRatioValid": true,
    ///           "CurrentTimeStamp": "2020-11-16T14:50:03.5513363+01:00",
    ///           "LastMaintenanceCounterValue": 102.0,
    ///           "LastMaintenanceTimeStamp": "2020-10-16T14:50:03.5513363+02:00",
    ///           "LastMaintenanceValid": false
    ///         }
    ///       ],
    ///       "SensorDetails": [
    ///         {
    ///           "Type": "Temperature",
    ///           "CustomSensorType": null,
    ///           "Value": 19.2,
    ///           "LowLimit": 15.0,
    ///           "HighLimit": 30.0,
    ///           "UnitOfMeasure": "DegreeCelsius",
    ///           "CustomUnitOfMeasure": null,
    ///           "SampleTime": "2020-11-16T14:50:03.5513363+01:00",
    ///           "ResourceName": "Temperature sensor",
    ///           "ResourceIdentifier": null,
    ///           "ResourceType": "Sensor",
    ///           "ResourcePosition": "2_R",
    ///           "MaintenanceStatus": null
    ///         }
    ///       ],
    ///       "VerificationDetails": null
    ///     },
    ///     {
    ///       "UniqueIdentifier": "10000000-00 000-G1-GC__",
    ///       "Name": "SST34_1",
    ///       "CalibrationDetails": [
    ///         {
    ///           "CalibrationCode": "C123456",
    ///           "CalibrationType": "BoardCamera",
    ///           "Comments": "Done ok",
    ///           "Status": "Ok",
    ///           "CalibrationTime": "2020-11-16T14:50:03.5513363+01:00"
    ///         }
    ///       ],
    ///       "ErrorDetails": null,
    ///       "MaintenanceDetails": null,
    ///       "SensorDetails": null,
    ///       "VerificationDetails": [
    ///         {
    ///           "Name": "FCCSCalibration",
    ///           "Status": "Ok",
    ///           "Value": 0.0,
    ///           "UnitOfMeasure": null,
    ///           "VerificationLocation": "1.2",
    ///           "Type": "Special",
    ///           "IsValid": true,
    ///           "LastExecution": "2020-11-16T14:50:03.5513363+01:00",
    ///           "Comment": null
    ///         },
    ///         {
    ///           "Name": "FCCSCleaningRequired",
    ///           "Status": "Failed",
    ///           "Value": 0.0,
    ///           "UnitOfMeasure": null,
    ///           "VerificationLocation": "2.3",
    ///           "Type": "General",
    ///           "IsValid": true,
    ///           "LastExecution": "2020-11-16T14:50:03.5513363+01:00",
    ///           "Comment": null
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UniqueIdentifier": "08ASMS500240",
    ///       "Name": "8mm-X Tape_2.40",
    ///       "CalibrationDetails": null,
    ///       "ErrorDetails": null,
    ///       "MaintenanceDetails": [
    ///         {
    ///           "Name": "FeederCycleCount",
    ///           "CounterType": "ActivityCount",
    ///           "CustomCounterType": null,
    ///           "MeasurementLocation": "08ASMS500240_Lane_1",
    ///           "CurrentCounterValue": 57002.0,
    ///           "CurrentRatio": 31.2,
    ///           "CurrentRatioValid": true,
    ///           "CurrentTimeStamp": "2020-11-16T14:50:03.5513363+01:00",
    ///           "LastMaintenanceCounterValue": 23456.0,
    ///           "LastMaintenanceTimeStamp": "2020-09-16T14:50:03.5513363+02:00",
    ///           "LastMaintenanceValid": false
    ///         }
    ///       ],
    ///       "SensorDetails": null,
    ///       "VerificationDetails": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ResourceMaintenanceAndServiceEvent : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ResourceMaintenanceAndServiceEvent()
        {
            
        }

        /// <summary>
        /// The date time of the event
        /// </summary>
        public DateTime? EventDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// The barcode, RFID, or other unique identifier that is used to identify this machine / endpoint.
        /// NOTE: in case the resource is not attached to the endpoint / machine, this field shall be null
        /// </summary>
        public Resource Machine
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure that describes the details of this maintenance and service.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public  List<ServiceAndMaintenanceData> MachineServiceAndMaintenanceData
        {
            get;
            set;
        }
    }
}
