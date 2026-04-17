using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Generic
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// A flexible <see cref="ProcessData"/> variant suitable for a wide range of equipment
    /// that does not have (or does not need) a dedicated process-specific structure.
    /// <para></para>
    /// Communicates three kinds of information captured during processing of a production
    /// unit or a collection of units:
    /// <list type="bullet">
    /// <item><description><b>Setpoints</b> — single numeric values corresponding to configured
    /// parameters of the equipment program (for example, the setpoint temperature of a
    /// heater).</description></item>
    /// <item><description><b>Readings</b> — measured numeric values captured during the
    /// processing of a unit, optionally reported with ideal values and acceptable
    /// limits.</description></item>
    /// <item><description><b>Parameters</b> — other non-numerical information that needs to
    /// be communicated, reported as name / string-value pairs.</description></item>
    /// </list>
    /// <para></para>
    /// When the equipment has multiple stages and similar information is reported for each
    /// stage, that per-stage information is reported in the <see cref="StageData"/> list,
    /// which contains one <see cref="GenericStageData"/> entry per stage.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class GenericProcessData : ProcessData
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GenericProcessData()
        {
            Setpoints = new List<GenericValue>();
            Readings = new List<GenericValue>();
            Parameters = new List<GenericParameter>();
            StageData = new List<GenericStageData>();
        }

        /// <summary>
        /// The set of configured numeric setpoints that were active during processing
        /// (for example, recipe-level setpoints that do not vary by stage).
        /// </summary>
        public List<GenericValue> Setpoints
        {
            get;
            set;
        }

        /// <summary>
        /// The set of numeric readings that were measured during processing
        /// (for example, overall cycle time or whole-machine telemetry).
        /// </summary>
        public List<GenericValue> Readings
        {
            get;
            set;
        }

        /// <summary>
        /// Other non-numerical named parameters that were captured during processing
        /// (communicated as name / string-value pairs).
        /// </summary>
        public List<GenericParameter> Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Optional list of per-stage process data, populated when the equipment has
        /// multiple stages that each report their own setpoints, readings, and parameters.
        /// </summary>
        public List<GenericStageData> StageData
        {
            get;
            set;
        }
    }
}
