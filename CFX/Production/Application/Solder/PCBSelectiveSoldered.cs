using System;
using System.Collections.Generic;
using System.Text;
using CFX;
using CFX.Structures;
using CFX.Structures.SolderApplication;

namespace CFX.Production.Application.Solder
{
    /// <summary>
    /// Message sent upon completion of the selective soldering process
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "c4d6262d-95cb-43e6-8b5c-dfd45978dd40",
    ///   "HeaderData": {
    ///     "Process_Status": "Completed",
    ///     "RecipeName": "Panasonic 2up",
    ///     "Nitrogen_Pressure": 54.0,
    ///     "Air_Pressure": 62.0,
    ///     "Cycle_Count": 671261,
    ///     "Cycle_Time": "00:01:44.2000000",
    ///     "Nitrogen_Purity": 15.0,
    ///     "Nitrogen_Flow": 39.0,
    ///     "Fiducial_Enabled": true
    ///   },
    ///   "SolderedPCBs": [
    ///     {
    ///       "UnitIdentifier": "PANEL4325435",
    ///       "UnitPositionNumber": 1,
    ///       "ZoneData": [
    ///         {
    ///           "StageSequence": 1,
    ///           "ProcessTime": "00:15:00",
    ///           "Bottle1_Pressure": 7.0,
    ///           "Bottle2_Pressure": 7.0,
    ///           "Flux_Volume": 210.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 0.0,
    ///           "Bot_Preheater_Soak": 0.0,
    ///           "Bot_Preheater_Temp": 0.0,
    ///           "Bot_Preheater_Time": "00:00:00",
    ///           "Bath_Temp": 0.0,
    ///           "Bath_Wave_Enabled": false,
    ///           "Bath_Wave_Hgt": 0.0,
    ///           "Solder_Quantity_Used": 0.0,
    ///           "Fid_XCorrection": 0.15,
    ///           "Fid_YCorrection": 0.2
    ///         },
    ///         {
    ///           "StageSequence": 2,
    ///           "ProcessTime": "00:00:37",
    ///           "Bottle1_Pressure": 0.0,
    ///           "Bottle2_Pressure": 0.0,
    ///           "Flux_Volume": 0.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 50.0,
    ///           "Bot_Preheater_Soak": 10.0,
    ///           "Bot_Preheater_Temp": 108.0,
    ///           "Bot_Preheater_Time": "00:00:37",
    ///           "Bath_Temp": 0.0,
    ///           "Bath_Wave_Enabled": false,
    ///           "Bath_Wave_Hgt": 0.0,
    ///           "Solder_Quantity_Used": 0.0,
    ///           "Fid_XCorrection": 0.0,
    ///           "Fid_YCorrection": 0.0
    ///         },
    ///         {
    ///           "StageSequence": 3,
    ///           "ProcessTime": "00:00:37",
    ///           "Bottle1_Pressure": 0.0,
    ///           "Bottle2_Pressure": 0.0,
    ///           "Flux_Volume": 0.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 50.0,
    ///           "Bot_Preheater_Soak": 10.0,
    ///           "Bot_Preheater_Temp": 108.0,
    ///           "Bot_Preheater_Time": "00:00:37",
    ///           "Bath_Temp": 305.0,
    ///           "Bath_Wave_Enabled": true,
    ///           "Bath_Wave_Hgt": 0.1,
    ///           "Solder_Quantity_Used": 5.0,
    ///           "Fid_XCorrection": 0.15,
    ///           "Fid_YCorrection": 0.2
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL4325435",
    ///       "UnitPositionNumber": 1,
    ///       "ZoneData": [
    ///         {
    ///           "StageSequence": 1,
    ///           "ProcessTime": "00:15:00",
    ///           "Bottle1_Pressure": 7.0,
    ///           "Bottle2_Pressure": 7.0,
    ///           "Flux_Volume": 210.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 0.0,
    ///           "Bot_Preheater_Soak": 0.0,
    ///           "Bot_Preheater_Temp": 0.0,
    ///           "Bot_Preheater_Time": "00:00:00",
    ///           "Bath_Temp": 0.0,
    ///           "Bath_Wave_Enabled": false,
    ///           "Bath_Wave_Hgt": 0.0,
    ///           "Solder_Quantity_Used": 0.0,
    ///           "Fid_XCorrection": 0.15,
    ///           "Fid_YCorrection": 0.2
    ///         },
    ///         {
    ///           "StageSequence": 2,
    ///           "ProcessTime": "00:00:37",
    ///           "Bottle1_Pressure": 0.0,
    ///           "Bottle2_Pressure": 0.0,
    ///           "Flux_Volume": 0.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 50.0,
    ///           "Bot_Preheater_Soak": 10.0,
    ///           "Bot_Preheater_Temp": 108.0,
    ///           "Bot_Preheater_Time": "00:00:37",
    ///           "Bath_Temp": 0.0,
    ///           "Bath_Wave_Enabled": false,
    ///           "Bath_Wave_Hgt": 0.0,
    ///           "Solder_Quantity_Used": 0.0,
    ///           "Fid_XCorrection": 0.0,
    ///           "Fid_YCorrection": 0.0
    ///         },
    ///         {
    ///           "StageSequence": 3,
    ///           "ProcessTime": "00:00:37",
    ///           "Bottle1_Pressure": 0.0,
    ///           "Bottle2_Pressure": 0.0,
    ///           "Flux_Volume": 0.0,
    ///           "Top_Preheater_Power": 50.0,
    ///           "Top_Preheater_Soak": 10.0,
    ///           "Top_Preheater_Temp": 109.0,
    ///           "Top_Preheater_Time": "00:00:37",
    ///           "Bot_Preheater_Power": 50.0,
    ///           "Bot_Preheater_Soak": 10.0,
    ///           "Bot_Preheater_Temp": 108.0,
    ///           "Bot_Preheater_Time": "00:00:37",
    ///           "Bath_Temp": 305.0,
    ///           "Bath_Wave_Enabled": true,
    ///           "Bath_Wave_Hgt": 0.1,
    ///           "Solder_Quantity_Used": 5.0,
    ///           "Fid_XCorrection": 0.15,
    ///           "Fid_YCorrection": 0.2
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <remarks>
    /// This was an early message; the standard has since moved to the
    /// <see cref="UnitsProcessed"/> with 
    /// <see cref="SelectiveSolderPCBProcessData"/> as the data being sent. You
    /// should prefer using these over the <c>PCBSelectiveSoldered</c>.
    /// </remaks>
    /// </summary>
    public class PCBSelectiveSoldered : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PCBSelectiveSoldered()
        {
        }

        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// General data values that apply across the selective process cycle
        /// </summary>
        public SelectiveSolderData HeaderData
        {
            get;
            set;
        }

        /// <summary>
        /// Details of PCB that has been processed.
        /// </summary>
        public List<SelectiveSolderedPCB> SolderedPCBs
        {
            get;
            set;
        }
    }
}
