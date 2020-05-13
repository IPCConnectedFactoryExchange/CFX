using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Response to a request to obtain detailed information about one or more material packages
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "Materials": [
    ///     {
    ///       "UniqueIdentifier": "MAT4566556456",
    ///       "InternalPartNumber": "IPN47788",
    ///       "Manufacturer": "MOTOROLA",
    ///       "ManufacturerPartNumber": "MOT231234",
    ///       "Vendor": "Digikey",
    ///       "VendorPartNumber": "DIG23452442",
    ///       "ManufacturerLotCode": "LOT2016110588",
    ///       "Created": "2019-08-30T08:57:38.8044515-04:00",
    ///       "ManufactureDate": "2016-11-05T00:00:00",
    ///       "ReceivedDate": "2017-05-06T00:00:00",
    ///       "ExpiryDate": null,
    ///       "Units": null,
    ///       "InitialQuantity": 1000.0,
    ///       "Quantity": 887.0,
    ///       "Status": "Active",
    ///       "HazardousMaterialType": "RoHS",
    ///       "MaterialData": {
    ///         "$type": "CFX.Structures.MaterialPackageMSDData, CFX",
    ///         "ExpirationDateTime": null,
    ///         "OriginalExposureDateTime": "2017-05-01T08:22:12",
    ///         "LastExposureDateTime": "2017-05-06T13:55:33",
    ///         "RemainingExposureTime": "6.00:00:00",
    ///         "MSDLevel": "MSL3",
    ///         "MSDState": "InDryStorage"
    ///       }
    ///     },
    ///     {
    ///       "UniqueIdentifier": "MAT4566554543",
    ///       "InternalPartNumber": "IPN48899",
    ///       "Manufacturer": "SAMSUNG",
    ///       "ManufacturerPartNumber": "SAM233243",
    ///       "Vendor": "Digikey",
    ///       "VendorPartNumber": "DIG44543534",
    ///       "ManufacturerLotCode": "LOT2016101008",
    ///       "Created": "2019-08-30T08:57:38.8044515-04:00",
    ///       "ManufactureDate": "2016-10-10T00:00:00",
    ///       "ReceivedDate": "2017-09-09T00:00:00",
    ///       "ExpiryDate": null,
    ///       "Units": null,
    ///       "InitialQuantity": 1000.0,
    ///       "Quantity": 748.0,
    ///       "Status": "Active",
    ///       "HazardousMaterialType": "NotHazardous",
    ///       "MaterialData": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class GetMaterialInformationResponse : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GetMaterialInformationResponse()
        {
            Result = new RequestResult();
            Materials = new List<MaterialPackageDetail>();
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
        /// A list of structures containing the detailed information about the material packages that were requested.
        /// </summary>
        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
