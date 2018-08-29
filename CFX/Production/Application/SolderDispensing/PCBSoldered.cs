using System;
using System.Collections.Generic;
using System.Text;
using CFX;
using CFX.Structures;
using CFX.Structures.SolderDispensing;

namespace CFX.Production.Application.SolderDispensing
{
    /// <summary>
    /// Message sent upon completion of the selective soldering process
    /// <code language="none">
    /// {
    ///    "TransactionId": "31aaff27-ec09-4c75-8de0-2d6cf2855e5f",
    ///    "HeaderData":{
    ///        "UnitIdentifier":"PANEL23423432",
    ///        "UnitPositionNumber":1,
    ///        "Process_Status":"Completed",
    ///        "RecipeName":"Panasonic 2up",
    ///        "Nitrogen_Pressure":"54",
    ///        "Air_Pressure":"62",
    ///        "Cycle_Count":"671261",
    ///        "Cycle_Time":"0:1:44.2",
    ///        "Nitrogen_Purity":"15",
    ///        "Nitrogen_Flow":"39",
    ///        "Fiducial_Enabled":"True"
    ///    },
    ///    "ZoneData":[
    ///        {
    ///            "Zone":"1",
    ///            "ProcessTime":"0:0:15",
    ///            "Bottle1_Pressure":"7.0",
    ///            "Bottle2_Pressure":"7.0",
    ///            "Flux_Volume":"210",
    ///            "Top_Preheater_Power":"50",
    ///            "Top_Preheater_Soak":"10",
    ///            "Top_Preheater_Temp":"109",
    ///            "Top_Preheater_Time":"0:0:37",
    ///            "Fid_XCorrection":"0.15",
    ///            "Fid_YCorrection":"0.2"
    ///        },
    ///        {
    ///            "Zone":"2",
    ///            "ProcessTime":"0:0:20",
    ///            "Top_Preheater_Power":"50",
    ///            "Top_Preheater_Soak":"10",   
    ///            "Top_Preheater_Temp":"109",
    ///            "Top_Preheater_Time":"0:0:37",
    ///            "Bot_Preheater_Power":"50",
    ///            "Bot_Preheater_Soak":"10"
    ///            "Bot_Preheater_Temp":"108",
    ///            "Bot_Preheater_Time":"0:0:37",
    ///        },
    ///        {
    ///            "Zone":"3",
    ///            "ProcessTime":"0:0:45",
    ///            "Bath_Temp":"305",
    ///            "Bath_Wave_Enabled":"True",
    ///            "Bath_Wave_Hgt":"0.1",
    ///            "Solder_Quantity_Used":"5",
    ///            "Top_Preheater_Power":"50",
    ///            "Top_Preheater_Soak":"10",
    ///            "Top_Preheater_Temp":"109",
    ///            "Top_Preheater_Time":"0:0:37",
    ///            "Bot_Preheater_Power":"50",
    ///            "Bot_Preheater_Soak":"10",
    ///            "Bot_Preheater_Temp":"108",
    ///            "Bot_Preheater_Time":"0:0:37",
    ///            "Fid_XCorrection":"0.15",
    ///            "Fid_YCorrection":"0.2"
    ///            }
    ///          ]
    ///       }
    ///    ]
    /// </code>
    /// </summary>
    public class PCBSoldered : CFXMessage
    {
        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Details of PCB that has been processed.
        /// </summary>
        public List<SolderedPCB> SolderedPCBs
        {
            get;
            set;
        }
    }
}
