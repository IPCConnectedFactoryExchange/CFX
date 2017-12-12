using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class GetRequiredSetupRequest : CFXMessage
    {
        /// <summary>
        /// An optional property designating the specific Lane.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Stage.
        /// </summary>
        public string Stage
        {
            get;
            set;
        }
    }
}
