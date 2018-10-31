using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// A dynamic structure which describes a fault that has occurred in the course of production.
    /// May be one of:  <see cref="CFX.Structures.Fault"/>, <see cref = "CFX.Structures.SMTPlacement.SMTPlacementFault" />,
    /// <see cref="CFX.Structures.SolderPastePrinting.SMTSolderPastePrintingFault"/>, or <see cref="CFX.Structures.THTInsertion.THTInsertionFault"/>
    /// </summary>
    public class Fault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fault"/> class.
        /// </summary>
        public Fault()
        {
            Cause = FaultCause.MechanicalFailure;
            Severity = FaultSeverity.Information;
            FaultOccurrenceId = Guid.NewGuid();
            AccessType = AccessType.Unknown;
            Created = DateTime.Now;
            SideLocation = SideLocation.Unknown;
            DescriptionTranslations = new Dictionary<string, string>();
        }

        /// <summary>
        /// The cause of this fault.
        /// </summary>
        public FaultCause Cause
        {
            get;
            set;
        }

        /// <summary>
        /// The severity of the fault
        /// </summary>
        public FaultSeverity Severity
        {
            get;
            set;
        }

        /// <summary>
        /// An endpoint specific code indicating the nature of the fault
        /// </summary>
        public string FaultCode
        {
            get;
            set;
        }

        /// <summary>
        /// A 128-bit unique identifier which uniquely identifier this specific 
        /// occurrence of the fault
        /// </summary>
        public Guid FaultOccurrenceId
        {
            get;
            set;
        }

        /// <summary>
        /// The production lane related to this fault (if applicable)
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The production stage related to this fualt (if applicable)
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The Side location is giving an indication for the operator from which side in transport direction of the PCB unit
        /// the fault or error can be accessed and fixed.
        /// </summary>
        public SideLocation SideLocation
        {
            get;
            set;
        }

        /// The Access Type is giving an indication for the line engineer if the fault, error or warning messages in the fault object
        /// can be handled via a remote terminal session to the equipment
        public AccessType AccessType
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets the description of the fault in English.
        ///  Max length of value is 1024 characters which might include multi-line text.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description translations for other languages than English.
        /// This is a dictionary of language tags and the corresponding translation in that language.
        /// The key values are either Cultures or Locales as defined in
        /// <a href="https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo(v=vs.110).aspx#CultureNames">
        /// Culture
        /// names and identifiers
        /// </a>
        /// .
        /// <remarks>
        /// Max length of key is 10 characters.
        /// <para />
        /// Max length of value is 1024 characters which might include multi-line text.
        /// <para />
        /// Filling this collection is optional.
        /// The CultureInfo class specifies a unique name for each culture, based on RFC 4646.
        /// The name is a combination of an ISO 639 two-letter lowercase culture code associated with a language and an
        /// ISO 3166 two-letter uppercase subculture code associated with a country or region.
        /// </remarks>
        /// <example>
        /// The language needs to be associated with the particular region where it is spoken,
        /// and this is done by using locale (language + location). For example: fr is the code for French language.
        /// fr-FR means French language in France. So, fr specifies only the language whereas fr-FR is the locale
        /// </example>
        /// </summary>
        /// <value>
        /// The description translations.
        /// </value>
        public Dictionary<string, string> DescriptionTranslations { get; set; }


        /// <summary>
        /// The date / time when this fault was created on the equipment
        /// </summary>
        public DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the due date time.
        /// If this is set, the fault must be resolved until the specified due time which is calculated by the equipment.
        /// Any fault which requires immediate attention must have a due date which is before Now time stamp.
        /// <remarks>This value is optional</remarks>
        /// </summary>
        /// <value>
        /// The due date time.
        /// </value>
        public DateTime? DueDateTime { get; set; }
    }
}
