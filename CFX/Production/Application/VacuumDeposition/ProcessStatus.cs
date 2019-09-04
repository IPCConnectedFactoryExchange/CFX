using System;
using CFX.Structures;

namespace CFX.Production.Application.VaccumDeposition
{
    /// <summary>
    /// Sent by a process endpoint. Provides status of the conformal coating process.
    /// <code language="none">
    /// "{
    ///     "TransactionID":"97386f9b-fbf1-4461-8f66-dd7dd4d157d7",
    ///     "Process_Step":
    ///     {
    ///         "System Pressure Test"
    ///     }
    ///     "Type":"ProcessStatus"
    ///  }
    /// </code>
    /// </summary>
    public class ProcessStatus : CFXMessage
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ProcessStatus()
        {
            TransactionID = Guid.NewGuid();
            ProcessState = new CoatingProcessState();
            Type = CoatingProcessState.MessageType.ProcessStatus;
        }

        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message.
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// Coating cycle status.
        /// </summary>
        public CoatingProcessState ProcessState
        {
            get;
            set;
        }

        /// <summary>
        /// Message type. Process status or Process error.
        /// </summary>
        public CoatingProcessState.MessageType Type
        {
            get;
            set;
        }
    }
}
