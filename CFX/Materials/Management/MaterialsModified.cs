using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent when the attributes of one or more specific material packages have been altered.
    /// NOTEL  When the current quantity attribute of the material package decreases in the 
    /// normal course of production (consumption), a MaterialsModified modified message should NOT
    /// be sent.  Instead, in this case a <see cref="MaterialsConsumed"/> message should be sent.
    /// <code language="none">
    /// {
    ///   "Reason": "ManualCountAndQuantityUpdate",
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
    ///         "ExpirationDateTime": null,
    ///         "OriginalExposureDateTime": "2017-05-01T08:22:12",
    ///         "LastExposureDateTime": "2017-05-06T13:55:33",
    ///         "RemainingExposureTime": "6.00:00:00",
    ///         "MSDLevel": "MSL2A",
    ///         "MSDState": "Exposed"
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsModified : CFXMessage
    {
        public MaterialsModified()
        {
            Materials = new List<MaterialPackageDetail>();
        }

        /// <summary>
        /// The reason for the changes
        /// </summary>
        public MaterialModifyReason Reason
        {
            get;
            set;
        }

        /// <summary>
        /// A list of material packages, including the updated information
        /// </summary>
        public List<MaterialPackageDetail> Materials
        {
            get;
            set;
        }
    }
}
