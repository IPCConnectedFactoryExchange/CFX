using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when one or more materials (see note) are installed on to a production unit. 
    /// This message is typically sent at the completion of production on a unit or group of units at the
    /// endpoint, or, at the end of each stage.
    /// </summary>
    public class MaterialsInstalled : CFXMessage
    {
        public MaterialsInstalled()
        {
            InstalledMaterials = new List<InstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific materials which were installed.
        /// </summary>
        public List<InstalledMaterial> InstalledMaterials
        {
            get;
            set;
        }
    }
}
