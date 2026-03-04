using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.VaporPhaseSoldering
{
    /// Top View:
    ///  
    ///                                      HeaterSideBack 
    ///                                            |
    ///                                            v  
    ///                     _________________________________________________
    ///                    |                                                 |
    ///                    |                                                 |    
    ///                    |                                                 |
    /// HeaterSideInlet -> |                                                 | <- HeaterSideOutlet
    ///                    |                                                 |
    ///                    |                                                 |
    ///                    |_________________________________________________|  
    ///                                            ^
    ///                                            |
    ///                                     HeaterSideFront    
    ///                                            
    ///                                            O  
    ///                                           /|\  (user view)
    ///                                           / \
    /// 
    /// 
    /// Front View:
    ///  
    ///                                      HeaterChamberTop 
    ///                                            |
    ///                                            v  
    ///                     _________________________________________________
    ///                    |                                                 |
    ///                    |                                                 |    
    ///                    |                       O                         |
    /// HeaterSideInlet -> |                      /|\  (user view)           | <- HeaterSideOutlet
    ///                    |                      / \                        |
    ///                    |                                                 |
    ///                    |_________________________________________________|  
    ///                              ^          ^         ^          ^
    ///                              |          |         |          |
    ///                                       Heaters Bottom    
    ///                                            
    ///                                              
    ///                                           
    ///                                           
    /// 
    /// Vapor Phase Soldering Process Data
    /// <summary>
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
        /// Temperature left outlet
        /// </summary>
        public NumericMeasurement HeaterSideOutlet
        {
            get;
            set;
        }

        /// <summary>
        /// Temperature right inlet
        /// </summary>
        public NumericMeasurement HeaterSideInlet
        {
            get;
            set;
        }


        /// <summary>
        /// Temperature front
        /// </summary>
        public NumericMeasurement HeaterSideFront
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
        /// Process Window Index (PWI) (0-100%) - a value of 100 means that the process is perfect, a value of 0 means that the process is not acceptable.
        /// The PWI is calculated based on the process chamber monitoring of the temperature.
        /// </summary>
        public NumericMeasurement ProcessWindowIndex
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
        /// Maximum temperature of the chamber.
        /// </summary>
        public NumericValue MaximumTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// Smallest air-pressure of the chamber.
        /// </summary>
        public NumericValue SmallestChamberPressure
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling duration of the first step in seconds.
        /// </summary>
        public NumericValue CoolingDurationStep1
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling frequency of the first step in hz.
        /// </summary>
        public NumericValue CoolingFrequencyStep1Top
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling frequency of the second step in hz.
        /// </summary>
        public NumericValue CoolingFrequencyStep1Bottom
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling duration of the second step in seconds.
        /// </summary>
        public NumericValue CoolingDurationStep2
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling frequency of the first step in hz.
        /// </summary>
        public NumericValue CoolingFrequencyStep2Top
        {
            get;
            set;
        }

        /// <summary>
        /// Cooling frequency of the second step in hz.
        /// </summary>
        public NumericValue CoolingFrequencyStep2Bottom
        {
            get;
            set;
        }
    }
}
