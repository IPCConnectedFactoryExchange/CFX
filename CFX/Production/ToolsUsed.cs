using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when one or more tools are used in the course of performing an assembly operation.
    /// <para>JSON Example - SMT Placement Machine</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "ff199a2e-4b31-4321-8afe-eff177f1a860",
    ///   "UsedTools": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "Tool": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMTHeadAndNozzle, CFX",
    ///         "HeadId": "HEAD1",
    ///         "HeadNozzleNumber": 2,
    ///         "NozzleType": "409A",
    ///         "UniqueIdentifier": "UID234213421",
    ///         "Name": "Nozzle45"
    ///       },
    ///       "UsageCycles": 3,
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "Tool": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMTHeadAndNozzle, CFX",
    ///         "HeadId": "HEAD2",
    ///         "HeadNozzleNumber": 3,
    ///         "NozzleType": "409A",
    ///         "UniqueIdentifier": "UID234223422",
    ///         "Name": "Nozzle47"
    ///       },
    ///       "UsageCycles": 3,
    ///       "InstalledComponents": [
    ///         {
    ///           "ReferenceDesignator": "R1",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R2",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         },
    ///         {
    ///           "ReferenceDesignator": "R3",
    ///           "InstallationTime": "2018-10-25T08:46:46.6320834-04:00"
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>JSON Example - Hammer Used by Human in Manual Operation</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "8561b98b-21ba-47e6-810d-0917b58a4415",
    ///   "UsedTools": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "Tool": {
    ///         "UniqueIdentifier": "UID234228874",
    ///         "Name": "Hammer 45"
    ///       },
    ///       "UsageCycles": 3,
    ///       "InstalledComponents": []
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "Tool": {
    ///         "UniqueIdentifier": "UID234228874",
    ///         "Name": "Hammer 45"
    ///       },
    ///       "UsageCycles": 3,
    ///       "InstalledComponents": []
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class ToolsUsed : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ToolsUsed()
        {
            UsedTools = new List<ToolUsed>();
        }

        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the tools that were used
        /// </summary>
        public List<ToolUsed> UsedTools
        {
            get;
            set;
        }
    }
}
