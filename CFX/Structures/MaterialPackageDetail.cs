using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes detailed information about a particular material package (instance of
    /// material that is tracked, stocked, and used within the factory environment.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialPackageDetail
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialPackageDetail()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Helper method which converts the more detailed MaterialPackageDetail structure
        /// to the simplified <see cref="MaterialPackage"/> structure.
        /// </summary>
        /// <returns></returns>
        public MaterialPackage ToMaterialPackage()
        {
            MaterialPackage p = new MaterialPackage()
            {
                UniqueIdentifier = this.UniqueIdentifier,
                InternalPartNumber = this.InternalPartNumber,
                Quantity = this.Quantity
            };

            return p;
        }

        /// <summary>
        /// The unique identifier of the material package
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the material contained within this material package
        /// </summary>
        public string InternalPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the manufacturer of this material
        /// </summary>
        public string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the original manufacturer of the material
        /// </summary>
        public string ManufacturerPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the supplier from whom the material was purchased / supplied.
        /// </summary>
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the supplier or vendor of the material
        /// </summary>
        public string VendorPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The lot code applied to this batch of material by the original manufacturer of the material
        /// </summary>
        public string ManufacturerLotCode
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material package was introduced into the factory environment
        /// </summary>
        public DateTime? Created
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material was originally manufactured by the manufacturer
        /// </summary>
        public DateTime? ManufactureDate
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material was received into the factory
        /// </summary>
        public DateTime? ReceivedDate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the expiry date of this material package based on manufacture definitions.
        /// </summary>
        /// <value>The expiry date.</value>
        public DateTime? ExpiryDate
        {
            get;
            set;
        }

        

        /// <summary>
        /// The unit of measure for this material (items, liters, meters, grams, etc.)
        /// Only valid SI units of measure should be utilized
        /// </summary>
        public string Units
        {
            get;
            set;
        }

        /// <summary>
        /// The initial quantity of material contained within this material package at the time
        /// when it was initialized / introduced into the factory environment
        /// </summary>
        public double InitialQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material presently contained within this material package
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// The current status of this material package
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.None)]
        public MaterialStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies whether or not a material is hazardous, and if so, the regulatory directive that controls
        /// the use of this substance in production.
        /// </summary>
        public HazardousMaterialType HazardousMaterialType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional dynamic structure containing specialized information about this material package.
        /// For example, if the material package contains moisture sensitive devices, this would contain
        /// additional information specific to MSD material handling (exposure time, etc.).
        /// </summary>
        public MaterialPackageData MaterialData
        {
            get;
            set;
        }
    }
}
