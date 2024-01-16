using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public enum HeatingAggregateType
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
        IrEmitter
    }
}
