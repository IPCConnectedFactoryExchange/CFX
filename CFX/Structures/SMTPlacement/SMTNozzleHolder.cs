using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Desctibes a location on an SMT placement machine where a nozzle/tool may be stored.
    /// </summary>
    public class SMTNozzleHolder
    {
        /// <summary>
        /// Unique identifier of the nozzle holder (barcode, RFID, etc.)
        /// </summary>
        public string LocationUniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the nozzle holder location
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        /// <summary>
        /// If this nozzle holder is part of a nest or group of nozzle holders, 
        /// this is the nest or group name.
        /// </summary>
        public string BaseName
        {
            get;
            set;
        }
    }
}
