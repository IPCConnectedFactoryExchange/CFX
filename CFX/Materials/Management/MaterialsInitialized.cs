using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent whan one or more new material packages are introduced into the factory environment.  
    /// This might occurr when new material is received from suppliers, or when newly received
    /// material is labeled with unique identifiers for tracking, stocking, or production purposes.
    /// <code language="none">
    /// {
    ///   "Materials": [
    ///     {
    ///       "UniqueIdentifier": "MAT4566556456",
    ///       "InternalPartNumber": "IPN47788",
    ///       "Manufacturer": "MOTOROLA",
    ///       "ManufacturerPartNumber": "MOT231234",
    ///       "Vendor": "Digikey",
    ///       "VendorPartNumber": "DIG23452442",
    ///       "ManufacturerLotCode": "LOT2016110588",
    ///       "Created": "2018-09-28T12:47:59.1991055-04:00",
    ///       "ManufactureDate": "2016-11-05T00:00:00",
    ///       "ReceivedDate": "2017-05-06T00:00:00",
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
    ///       "Created": "2018-09-28T12:47:59.1991055-04:00",
    ///       "ManufactureDate": "2016-10-10T00:00:00",
    ///       "ReceivedDate": "2017-09-09T00:00:00",
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
    public class MaterialsInitialized : CFXMessage
    {
        public MaterialsInitialized()
        {
            Materials = new List<MaterialPackageDetail>();
        }

        /// <summary>
        /// A list of the new material packages, including details
        /// </summary>
        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
