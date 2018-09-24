using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.Processing.ThermalProcessing
{
    /// <summary>
    /// Sent by a process endpoint after a unit undergoes thermal processing. Provides information regarding the experience of the unit during the thermal processing.
    /// <code language="none">
	/*
	{
		"TimeDateUnitIn": "20080915T155312",
		"TimeDateUnitOut": "20080915T155956",
		"ProductName": "product001",
		"Barcode": "barcode001",		
		"RecipeName": "recipe001",	
		"ProcessWindowName": "processwindow001",
		"LotID": "lotid001",
		"OvenName": "oven001",
		"Lane": 1,
		"ConveyorSpeedUnits": "MMPM",
		"ConveyorSpeedSetpoint": 1000.0,
		"MeasuredConveyorSpeed": 1024.0,
		"TemperatureUnits": "C",
		"Result": "PASS",
		"TemperatureSetPoints": [
			{
				"Zone": 1,
				"TopTemperatureSetpoint": 150.0,
				"BottomTemperatureSetpoint": 150.0
			},
			{
				"Zone": 2,
				"TopTemperatureSetpoint": 200.0,
				"BottomTemperatureSetpoint": 200.0
			}
		],
		"ProductionUnitPWI": 89.6,
		"ProductionUnitCpk": 1.67,
		"MaxRisingSlopeLimits": {
				"LowerSlopeLimit": 0.0,
				"UpperSlopeLimit ": 3.0
		},
		"SoakTimeLimits": {
				"LowerTimeLimit": 60.0,
				"UpperTimeLimit": 120.0,
				"LowerTempLimit": 100.0,
				"UpperTempLimit": 170.0
		},
		"ReflowTimeLimits": {
				"LowerTimeLimit ": 45.0,
				"UpperTimeLimit ": 90.0,
				"LowerTempLimit ": 183.0
		},
		"PeakTempLimits": {
				"LowerTempLimit ": 210.0,
				"UpperTempLimit ": 230.0
		},
		"ThermocoupleData": [
			{
				"Thermocouple": 1,
				"MaxRisingSlope": 1.26,
				"MaxRisingSlopePWI": 7.8,
				"SoakTime": 109.3,
				"SoakTimePWI": 89.6,
				"ReflowTime": 55.1,
				"ReflowTimePWI": -76.2,
				"PeakTemp": 215.1,
				"PeakTempPWI": -26.2
			},
			{
				"Thermocouple": 2,
				"MaxRisingSlope": 1.86,
				"MaxRisingSlopePWI": 56.8,
				"SoakTime": 86.8,
				"SoakTimePWI": 72.0,
				"ReflowTime": 62.5,
				"ReflowTimePWI": -3.7,
				"PeakTemp": 217.5,
				"PeakTempPWI": -15.4
			}
		]
	}
	*/
    /// </code>
    /// </summary>
    public class ProductionUnitSimulatedProfile : CFXMessage
    {
        /// <summary>
        /// BoardOut statistics of production unit
        /// </summary>
        public ThermalProcessingStatistics BoardOut
        {
            get;
            set;
        }
    }
}
