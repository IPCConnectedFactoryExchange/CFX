using System;

namespace CFX.Structures.VacuumDeposition
{
    /// <summary>
    /// Structure representing coating process fault.
    /// <code language="none">
    /// {
    ///   "TransactionId": "c16bb3f4-8088-4697-b789-80faec48ac5a",
    ///   "ProcessFault": "Pressure Failed To Rise",
    ///   "ElapsedTime" : "0 00:00:10",
    ///   "TimeStamp" : "2018-10-03T16:03:05.2842009-04:00"
    ///   }
    /// </code>
    /// </summary>
    public class CoatingFault : Fault
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CoatingFault()
        {
            TransactionId = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }

        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Coating process fault.
        /// </summary>
        public String ProcessFault
        {
            get;
            set;
        }
        /// <summary>
        /// Elapsed time since process start.
        /// </summary>
        public string ElapsedTime
        {
            get;
            set;
        }

        /// <summary>
        /// The time the fault occured.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            set;
        }
    }
}
