using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent when a a certain quantity of material is removed from a material package
    /// to form a new material package.  The sum of the new quantities of the old and 
    /// new material package packages should equal the quantity of the original package.
    /// <code language="none">
    /// {
    ///   "SourceMaterialPackageIdentifier": "MAT4566589856",
    ///   "SourceMaterialPackageRemainingQuantity": 121.0,
    ///   "NewMaterialPackageIdentifier": "MAT4563453457",
    ///   "NewMaterialPackageQuantity": 30.0
    /// }
    /// </code>
    /// </summary>
    public class MaterialsSplit : CFXMessage
    {
        /// <summary>
        /// The unique identifier of the original material package that is being divided
        /// </summary>
        public string SourceMaterialPackageIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material remaining in the original material package after
        /// it was divided
        /// </summary>
        public double SourceMaterialPackageRemainingQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identifier of the newly created material package
        /// </summary>
        public string NewMaterialPackageIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of material contained within newly created material package
        /// </summary>
        public double NewMaterialPackageQuantity
        {
            get;
            set;
        }
    }
}

