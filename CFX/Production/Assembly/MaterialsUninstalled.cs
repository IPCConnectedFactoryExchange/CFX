using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when one or more materials (see note) are removed from a production unit.
    /// This message is typically sent at the completion of a production unit or group of units at the
    /// endpoint, or, at the end of each stage.
    /// </summary>
    public class MaterialsUninstalled : CFXMessage
    {
        public MaterialsUninstalled()
        {
            UninstalledMaterials = new List<UninstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this uninstallation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of materials which have been uninstalled.
        /// </summary>
        public List<UninstalledMaterial> UninstalledMaterials
        {
            get;
            set;
        }
    }
}
