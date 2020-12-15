using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Response to an external source inquiring data regarding energy consumption of the endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
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
    [CFX.Utilities.CreatedVersion("1.3")]
    public class EnergyConsumptionResponse : CFXMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyConsumptionResponse"/> class.
        /// </summary>
        public EnergyConsumptionResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The start time of the sample period. 
        /// Start time is set as the start time of the immediately prior CFX.ResourcePerformance.EnergyConsumed message
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// The end time of the sample period. Coincides with the time when request was received.
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
        /// The average amount of power consumed during the sample period
        /// (in watts)
        /// </summary>
        public double MeanPower
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous amount of power recorded at EndTime
        /// (in watts)
        /// </summary>
        public double PowerNow
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// (Coefficient number between 0.0 and 1.0 )
        /// </summary>
        public double PowerFactorNow
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of current recorded during the sample period
        /// (in Ampere)
        /// </summary>
        public double PeakCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of current recorded during the sample period
        /// (in Ampere)
        /// </summary>
        public double MinimumCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// The average amount of current consumed during the sample period
        /// (in Ampere)
        /// </summary>
        public double MeanCurrent
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous amount of current recorded at EndTime
        /// (in Ampere)
        /// </summary>
        public double CurrentNow
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of voltage recorded during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public double PeakVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of voltage recorded during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public double MinimumVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// The average value of voltage measured during the sample period
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public double MeanVoltage
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous value of voltage recorded at EndTime
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public double VoltageNow
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        public double PeakFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        public double MinimumFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// The average frequency value recorded during the sample period
        /// (in Hertz)
        /// </summary>
        public double MeanFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous frequency value recorded at EndTime
        /// (in Hertz)
        /// </summary>
        public double FrequencyNow
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of power recorded during the sample period on three phases
        /// (in watts)
        /// </summary>
        public List<double> PeakPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The lowest amount of power recorded during the sample period on three phases
        /// (in watts)
        /// </summary>
        public List<double> MinimumPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The average amount of power consumed during the sample period on three phases
        /// (in watts)
        /// </summary>
        public List<double> MeanPowerRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous amount of power recorded at EndTime on three phases
        /// (in watts)
        /// </summary>
        public List<double> PowerNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// Description
        /// (Coefficient number between 0.0 and 1.0 )
        /// </summary>
        public List<double> PowerFactorNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of current recorded during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        public List<double> PeakCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of current recorded during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        public List<double> MinimumCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The average amount of current consumed during the sample period on three phases
        /// (in Ampere)
        /// </summary>
        public List<double> MeanCurrentRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous amount of current recorded at EndTime on three phases
        /// (in Ampere)
        /// </summary>
        public List<double> CurrentNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of voltage recorded during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public List<double> PeakVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum amount of voltage recorded during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public List<double> MinimumVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The average value of voltage measured during the sample period on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public List<double> MeanVoltageRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The instantaneous amount of voltage recorded at EndTime on three phases
        /// (in Volts DC or AC (RMS))
        /// </summary>
        public List<double> VoltageNowRYB
        {
            get;
            set;
        }

        /// <summary>
        /// The instantanous amount of current on Neutral at EndTime 
        /// (in Ampere)
        /// </summary>
        public double ThreePhaseNeutralCurrentNow
        {
            get;
            set;
        }
    }
}
