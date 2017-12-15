using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    public class SMDTapeFeeder : MaterialCarrier
    {
        public SMDTapeFeeder()
        {
            LaneNumber = 1;
        }

        /// <summary>
        /// For multi-lane feeders, the unique identifier of the base.  The UniqueIdentifier
        /// property should be populated with the unique identifer of the specific lane 
        /// within the feeder (if so labeled).  If lanes are not specifically labeled, both
        /// the UniqueIdentifer and BaseUniqueIdentifier prooperties should be populated
        /// with the same value.
        /// </summary>
        public string BaseUniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The friendly name of the tape feeder base.
        /// </summary>
        public string BaseName
        {
            get;
            set;
        }

        /// <summary>
        /// For multi-lane tape feeders, this is the number of the position
        /// of the lane within the feeder.
        /// </summary>
        public int LaneNumber
        {
            get;
            set;
        }

        public SMDTapeWidth Width
        {
            get;
            set;
        }

        public SMDTapePitch Pitch
        {
            get;
            set;
        }
    }
}
