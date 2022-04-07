using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Data for the cleaning process, applied to production units – this is the defluxing process – and tools, e.g. squeegees, stencils, etc.
    /// The defluxing process removes flux-deposits after reflow and takes care of cleaning 
    /// a production unit or a batch of production units. Cleaning of tools removes deposits, 
    /// e.g.solder paste, from tools, so that they can continued to be used.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CleaningProcessData : ProcessData
    {
        /// <summary>
        /// The speed (in cm / minute) of the conveyor
        /// </summary>
        public double ConveyorSpeed
        {
            get;
            set;
        }
        /// <summary>
        /// Cleaning time as specified in recipe expressed in seconds (s)
        /// </summary>
        public double CleaningTimeSet
        {
            get;
            set;
        }
        /// <summary>
        /// Actual cleaning time expressed in seconds (s)
        /// </summary>
        public double CleaningTimeActual
        {
            get;
            set;
        }
        /// <summary>
        /// A list of cleaning steps
        /// </summary>
        public List<CleaningStep> CleaningSteps
        {
            get;
            set;
        }
    }
}
