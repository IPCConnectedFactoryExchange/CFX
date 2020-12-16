using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint on a sampled interval of between 1 minute and 1 hour
    /// to indicate the energy usage and power consumption.
    /// <code language="none">
    /// {
    ///   "StartTime": "2018-04-05T09:33:06.1358356-04:00",
    ///   "EndTime": "2018-04-05T09:38:06.1358356-04:00",
    ///   "EnergyUsed": 0.012,
    ///   "PeakPower": 125.6,
    ///   "MinimumPower": 120.3,
    ///   "MeanPower": 124.6,
    ///   "PowerNow": 121.1,         
	///   "PowerFactorNow": 0.95,
	///   "PeakCurrent": 0.82,       
	///   "MinimumCurrent": 0.00,    
	///   "MeanCurrent": 0.68,       
	///   "CurrentNow": 0.69,       
	///   "PeakVoltage": 239.1,      
	///   "MinimumVoltage": 231.6,   
	///   "MeanVoltage": 232.9,      
	///   "VoltageNow": 212.1,       
	///   "PeakFrequency": 52,
	///   "MinimumFrequency": 50.5,
	///   "MeanFrequency": 50.6,
	///   “FrequencyNow": 50.6,
	///   "PeakPowerRYB": [ 125.6, 77.4, 10.2 ],
	///   "MinimumPowerRYB": [ 120.3, 68.5, 8.5 ],    
	///   "MeanPowerRYB": [ 124.6, 70.2, 9.8 ], 
	///   "PowerNowRYB": [ 121.1, 68.9, 10.1 ], 
	///   "PowerFactorNowRYB": [ 0.95, 0.92, 0.80 ],
	///   "PeakCurrentRYB": [ 0.82, 0.65, 0.33 ], 
	///   "MinimumCurrentRYB": [ 0.00, 0.01, 0.32 ], 
	///   "MeanCurrentRYB": [ 0.68, 0.58, 0.32 ],
	///   "CurrentNowRYB": [ 0.69, 0.57, 0.32 ], 
	///   "PeakVoltageRYB": [ 420.1, 413.7, 404.6 ], 
	///   "MinimumVoltageRYB": [ 393.6, 399.8, 397.4 ],
	///   "MeanVoltageRYB": [ 402.9, 400.1, 402.3 ],
	///   "VoltageNowRYB": [ 401.1, 401.5, 402.3 ], 
	///   "ThreePhaseNeutralCurrentNow": 0.06 
    /// }
    /// </code>
    /// </summary>
    public class EnergyConsumed : CFXMessage
    {
        /// <summary>
        /// The start time of the sample period
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// The end time of the sample period
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of energy consumed during the sample period
        /// (in kilowatt-hours)
        /// </summary>
        public double EnergyUsed
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of power recorded during the sample period
        /// (in watts)
        /// </summary>
        public double PeakPower
        {
            get;
            set;
        }

        /// <summary>
        /// The lowest amount of power recorded during the sample period
        /// (in watts)
        /// </summary>
        public double MinimumPower
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average amount of power consumed during the sample period
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MeanPower
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous amount of power recorded at EndTime
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PowerNow
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Description
        /// (Coefficient number between 0.0 and 1.0 )
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PowerFactorNow
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum amount of current recorded during the sample period
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PeakCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The minimum amount of current recorded during the sample period
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MinimumCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average amount of current consumed during the sample period
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MeanCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous amount of current recorded at EndTime
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double CurrentNow
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum amount of voltage recorded during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PeakVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The minimum amount of voltage recorded during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MinimumVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average value of voltage measured during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MeanVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous value of voltage recorded at EndTime
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double VoltageNow
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double PeakFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The minimum frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MinimumFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double MeanFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous frequency value recorded at EndTime
        /// (in Hertz)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double FrequencyNow
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum amount of power recorded during the sample period on three phases
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> PeakPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The lowest amount of power recorded during the sample period on three phases
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MinimumPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average amount of power consumed during the sample period on three phases
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MeanPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous amount of power recorded at EndTime on three phases
        /// (in watts)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> PowerNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Description
        /// (Coefficient number between 0.0 and 1.0 )
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> PowerFactorNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum amount of current recorded during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> PeakCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The minimum amount of current recorded during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MinimumCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average amount of current consumed during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MeanCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous amount of current recorded at EndTime on three phases
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> CurrentNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The maximum amount of voltage recorded during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> PeakVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The minimum amount of voltage recorded during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MinimumVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The average value of voltage measured during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> MeanVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantaneous amount of voltage recorded at EndTime on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public List<double> VoltageNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The instantanous amount of current on Neutral at EndTime 
        /// (in Ampere)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public double ThreePhaseNeutralCurrentNow
        {
            get;
            set;
        }

    }
}
