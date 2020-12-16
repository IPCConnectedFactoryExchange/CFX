using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management.MSDManagement
{
    /// <summary>
    /// Sent when one or more MSD material packages have been opened and exposed to the environment
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
    ///         "ExpirationDateTime": "2018-10-04T12:48:00.2221189-04:00",
    ///         "OriginalExposureDateTime": "2017-05-01T08:22:12",
    ///         "LastExposureDateTime": "2018-09-28T12:48:00.2221189-04:00",
    ///         "RemainingExposureTime": "6.00:00:00",
    ///         "MSDLevel": "MSL3",
    ///         "MSDState": "Exposed"
    ///       }
    ///     },
    ///     {
    ///       "UniqueIdentifier": "MAT4566553421",
    ///       "InternalPartNumber": "IPN45577",
    ///       "Manufacturer": "FUJITSU",
    ///       "ManufacturerPartNumber": "FJJT234243",
    ///       "Vendor": "Digikey",
    ///       "VendorPartNumber": "DIG543534537",
    ///       "ManufacturerLotCode": "LOT2017080355",
    ///       "Created": "2018-09-28T12:47:59.1991055-04:00",
    ///       "ManufactureDate": "2017-08-03T00:00:00",
    ///       "ReceivedDate": "2017-09-10T00:00:00",
    ///       "Units": null,
    ///       "InitialQuantity": 500.0,
    ///       "Quantity": 151.0,
    ///       "Status": "Active",
    ///       "HazardousMaterialType": "NotHazardous",
    ///       "MaterialData": {
    ///         "$type": "CFX.Structures.MaterialPackageMSDData, CFX",
    ///         "ExpirationDateTime": "2018-10-04T12:48:00.2221189-04:00",
    ///         "OriginalExposureDateTime": "2017-05-01T08:22:12",
    ///         "LastExposureDateTime": "2018-09-28T12:48:00.2221189-04:00",
    ///         "RemainingExposureTime": "6.00:00:00",
    ///         "MSDLevel": "MSL2A",
    ///         "MSDState": "Exposed"
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsOpened : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialsOpened()
        {
            Materials = new List<MaterialPackageDetail>();
        }

        /// <summary>
        /// The materials which have been opened / exposed
        /// </summary>
        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
