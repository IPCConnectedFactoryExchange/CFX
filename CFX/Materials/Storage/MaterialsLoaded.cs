using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    public class MaterialsLoaded : CFXMessage
    {
        public MaterialsLoaded()
        {
            Materials = new List<MaterialLocation>();
        }

        /// <summary>
        /// There are three usage cases are available for this message:
        ///     1) Load MaterialPackage directly to Endpoint 
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = null)
        ///     2) Load MaterialPackage to MaterialCarrier
        ///        (LocationIdentifier = null, CarrierInformation = Identifier of carrier to be loaded)
        ///     3) Load MaterialPackage to MaterialCarrier AND Load MaterialCarrier to Endpoint
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = Identifier of carrier to be loaded)
        /// </summary>
        public List<MaterialLocation> Materials
        {
            get;
            set;
        }
    }
}
