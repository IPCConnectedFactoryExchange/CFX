using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    public class Stage
    {
        public Stage()
        {
            StageSequence = 1;
            StageType = StageType.Work;
        }

        /// <summary>
        /// Sequence of this stage in the machine
        /// </summary>
        public int StageSequence
        {
            get;
            set;
        }

        /// <summary>
        /// A friendlly name for this stage
        /// </summary>
        public string StageName
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the purpose of this particular stage
        /// </summary>
        public StageType StageType
        {
            get;
            set;
        }
    }
}
