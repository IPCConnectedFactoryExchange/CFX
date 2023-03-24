namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// A specialized type of LogEntryRecordedData for an SMT machine
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class SMTLogEntryAdditionalData : LogEntryAdditionalData
    {
        /// <summary>
        /// The particular Head/Nozzle related to the log entry (where applicable)
        /// </summary>
        public SMTHeadAndNozzle HeadAndNozzle
        {
            get;
            set;
        }
    }
}
