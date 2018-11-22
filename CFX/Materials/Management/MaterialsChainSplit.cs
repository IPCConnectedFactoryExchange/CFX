using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent when a certain material package chain is is been modified by opening the
    /// splice plate and therefore create 2 material chains out of one.
    /// No new material ID will be created during this usecase.
    /// This use case is operatoed on the station. 
    /// </summary>
    public class MaterialsChainSplit : CFXMessage
    {
        /// <summary>
        /// The splitted chain is the packaging unit chain, which is removed from the machine
        /// </summary>
        public MaterialPackage SplittedMaterialPackage
        {
            get;
            set;
        }

        /// <summary>
        /// The material Chain is the packaging unit chain, which is remaining at the station.
        /// </summary>
        public MaterialPackage RemainingMaterialPackage
        {
            get;
            set;
        }
    }
}

