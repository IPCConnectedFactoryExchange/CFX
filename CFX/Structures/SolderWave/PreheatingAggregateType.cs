using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of heating aggregate types. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum PreheatingAggregateType
    {
        /// <summary>
        /// The heating process is based on a medium wave.
        /// </summary>
        MediumWave,
        /// <summary>
        /// Heating process is based on convection.
        /// </summary>
        Convection,
        /// <summary>
        /// The heating process is based on compressed air.
        /// </summary>
        CompressedAir,
        /// <summary>
        /// The heating process is based on an infrared emitter.
        /// </summary>
        IrEmitter,
        /// <summary>
        /// The heating process is based on a radiant heater.
        /// </summary>
        Radiant
    }
}
