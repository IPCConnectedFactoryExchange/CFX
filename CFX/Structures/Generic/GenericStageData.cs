using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Generic
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Represents the setpoints, readings, and parameters captured for a single stage
    /// of a multi-stage process.  Used within the <see cref="GenericProcessData.StageData"/>
    /// list when equipment reports similar process information for each stage.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class GenericStageData
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GenericStageData()
        {
            Setpoints = new List<GenericValue>();
            Readings = new List<GenericValue>();
            Parameters = new List<GenericParameter>();
        }

        /// <summary>
        /// The stage of the equipment that this process data pertains to.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The set of configured numeric setpoints that were active during processing
        /// at this stage (for example, zone temperature or fan speed setpoints).
        /// </summary>
        public List<GenericValue> Setpoints
        {
            get;
            set;
        }

        /// <summary>
        /// The set of numeric readings that were measured during processing at this stage
        /// (for example, actual temperatures, pressures, or flow rates).
        /// </summary>
        public List<GenericValue> Readings
        {
            get;
            set;
        }

        /// <summary>
        /// Other non-numerical named parameters that were captured during processing
        /// at this stage (communicated as name / string-value pairs).
        /// </summary>
        public List<GenericParameter> Parameters
        {
            get;
            set;
        }
    }
}
