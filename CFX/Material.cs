using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class Material
    {
        public Material()
        {
            InternalPartNumber = "";
            ManufacturerPartNumber = "";
            VendorPartNumber = "";
            Quantity = 0.0;
            UniqueIdentifier = Guid.NewGuid().ToString();
        }

        public string InternalPartNumber
        {
            get;
            set;
        }

        public string ManufacturerPartNumber
        {
            get;
            set;
        }

        public string VendorPartNumber
        {
            get;
            set;
        }

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string ManufacuterLotCode
        {
            get;
            set;
        }

        public DateTime ManufactureDate
        {
            get;
            set;
        }

        public DateTime ReceivedDate
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public string CurrentLocation
        {
            get;
            set;
        }
    }
}
