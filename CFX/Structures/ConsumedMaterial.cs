using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes an event where material is consumed in the course of production.
    /// </summary>
    public class ConsumedMaterial
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ConsumedMaterial()
        {
        }

        /// <summary>
        /// The location on the process endpoint from which the material was consumed.
        /// Also identifies the specific material package from which the material was 
        /// consumed (if known)
        /// </summary>
        public MaterialLocation MaterialLocation
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material that was consumed for value-added purposes
        /// </summary>
        public double QuantityUsed
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material that was spoiled (consumed, but not for value-added purposes)
        /// </summary>
        public double QuantitySpoiled
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material remaining in the material package after the consumption event
        /// </summary>
        public double RemainingQuantity
        {
            get;
            set;
        }
    }
}
