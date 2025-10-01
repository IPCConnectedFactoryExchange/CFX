using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// This class contains lists of transported materials.
    /// Per type of material, a dedicated list is provided.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class TransportedMaterial
    {
        /// <summary>
        /// A list of transported tools, null if not needed
        /// </summary>
        public List<Tool> TransportedTools { get; set; }

        ///<summary>
        ///A list of transported material packages, null if not needed
        ///</summary>
        public List<MaterialPackage> TransportedMaterialPackages { get; set; }  


    }
}
