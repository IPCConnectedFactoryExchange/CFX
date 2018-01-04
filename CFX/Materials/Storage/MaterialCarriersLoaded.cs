using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    public class MaterialCarriersLoaded : CFXMessage
    {
        public MaterialCarriersLoaded()
        {
            Carriers = new List<MaterialCarrierLocation>();
        }

        /// <summary>
        /// There are two usage cases are available for this message:
        ///     1) Load MaterialCarrier directly to Endpoint 
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = Carrier to be loaded)
        ///     2) Load MateriialCarrier to another MaterialCarrier
        ///        (LocationIdentifier = Identifier of new parent carrier, CarrierInformation = Identifier of carrier to be loaded)
        /// </summary>
        public List<MaterialCarrierLocation> Carriers
        {
            get;
            set;
        }
    }
}
