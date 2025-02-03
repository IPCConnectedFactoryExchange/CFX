using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.VaporPhaseSoldering
{
    /// <summary>
    /// Vapor Phase Soldering Process Data
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class VaporPhaseSolderingProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public VaporPhaseSolderingProcessData()
        {
            this.VaporPhaseSolderingProcessAbort = new VaporPhaseSolderingProcessAbort();
        }

        /// <summary>
        /// Proces abort
        /// </summary>
        public VaporPhaseSolderingProcessAbort VaporPhaseSolderingProcessAbort
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature floor 1
        /// </summary>
        public NumericMeasurement HeaterBottom1
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature floor 2
        /// </summary>
        public NumericMeasurement HeaterBottom2
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature floor 3
        /// </summary>
        public NumericMeasurement HeaterBottom3
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature floor 4
        /// </summary>
        public NumericMeasurement HeaterBottom4
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature left inlet
        /// </summary>
        public NumericMeasurement HeaterSideLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature right inlet
        /// </summary>
        public NumericMeasurement HeaterSideRight
        {
            get;
            set;
        }


        /// <summary>
        /// Temperature back
        /// </summary>
        public NumericMeasurement HeaterSideBack
        {
            get;
            set;
        }

        /// <summary>
        /// Temperatur process chamber 
        /// </summary>
        public NumericMeasurement HeaterChamberTop
        {
            get;
            set;
        }

        /// <summary>
        /// PWI
        /// </summary>
        public NumericMeasurement ProcessWindowIndex
        {
            get;
            set;
        }

        /// <summary>
        /// injection quantity evaluation
        /// </summary>
        public NumericMeasurement GaldenInjectionQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// Step 1-30 Status with evaluation (sucess, fail, warning, inactive) = 30 process steps.
        /// </summary>
        public List<VaporPhaseSolderingProcessStep> VaporPhaseSolderingProcessSteps 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Maximum temperature
        /// </summary>
        public NumericValue MaximumTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// Smallest air-pressure of the chamber
        /// </summary>
        public NumericValue SmallestChamberPressure
        {
            get;
            set;
        }
    }
}
