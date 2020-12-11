using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;
using CFX.Structures.Maintenance;

namespace CFX.Maintenance
{
    /// <summary>
    /// Allows any CFX endpoint to request the resource and sub-resources maintenance and services of a specified single endpoint. 
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "Machine": {
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SIPLACE SX4",
    ///     "ResourceType": null,
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
    ///           "CalibrationTime": "2020-11-26T18:27:14.8761185+01:00"
    ///         },
    ///         {
    ///           "CalibrationCode": "HeadMapping_0_R",
    ///           "CalibrationType": "HeadMapping",
    ///           "Comments": "Calibration failed. Check log",
    ///           "Status": "Failed",
    ///           "CalibrationTime": "2020-11-26T18:27:14.8771196+01:00"
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
    ///           "CurrentTimeStamp": "2020-11-26T18:27:14.8771196+01:00",
    ///           "LastMaintenanceCounterValue": 102.0,
    ///           "LastMaintenanceTimeStamp": "2020-10-26T18:27:14.8771196+01:00",
    ///           "LastMaintenanceValid": false
    ///         }
    ///       ],
    ///       "SensorDetails": [
    ///         {
    ///           "ResourceIdentifier": null,
    ///           "IdentiferUniqueness": "Unkwnown",
    ///           "ResourceName": "Temperature sensor",
    ///           "ResourceType": "Sensor",
    ///           "ResourcePosition": "2_R",
    ///           "MaintenanceStatus": null,
    ///           "AdditionalSubResources": null,
    ///           "Type": "Temperature",
    ///           "CustomSensorType": null,
    ///           "Value": 19.2,
    ///           "LowLimit": 15.0,
    ///           "HighLimit": 30.0,
    ///           "UnitOfMeasure": "DegreeCelsius",
    ///           "CustomUnitOfMeasure": null,
    ///           "SampleTime": "2020-11-26T18:27:14.8781183+01:00"
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
    ///           "CalibrationTime": "2020-11-26T18:27:14.8781183+01:00"
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
    ///           "LastExecution": "2020-11-26T18:27:14.8791189+01:00",
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
    ///           "LastExecution": "2020-11-26T18:27:14.8791189+01:00",
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
    ///           "CurrentTimeStamp": "2020-11-26T18:27:14.8791189+01:00",
    ///           "LastMaintenanceCounterValue": 23456.0,
    ///           "LastMaintenanceTimeStamp": "2020-09-26T18:27:14.8791189+02:00",
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

    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    [CFX.Utilities.CreatedVersion("1.3")]
    public class GetResourceMaintenanceAndServiceResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetResourceMaintenanceAndServiceResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
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
