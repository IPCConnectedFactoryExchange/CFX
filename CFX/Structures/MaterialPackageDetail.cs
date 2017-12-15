using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialPackageDetail
    {
        public MaterialPackageDetail()
        {
            Created = DateTime.Now;
        }

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

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string InternalPartNumber
        {
            get;
            set;
        }

        public string Manufacturer
        {
            get;
            set;
        }

        public string ManufacturerPartNumber
        {
            get;
            set;
        }

        public string Vendor
        {
            get;
            set;
        }

        public string VendorPartNumber
        {
            get;
            set;
        }

        public string ManufacuterLotCode
        {
            get;
            set;
        }

        public DateTime? Created
        {
            get;
            set;
        }

        public DateTime? ManufactureDate
        {
            get;
            set;
        }

        public DateTime? ReceivedDate
        {
            get;
            set;
        }

        public string Units
        {
            get;
            set;
        }

        public double InitialQuantity
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.None)]
        public MaterialStatus Status
        {
            get;
            set;
        }

        public MaterialPackageData MaterialData
        {
            get;
            set;
        }
    }
}
