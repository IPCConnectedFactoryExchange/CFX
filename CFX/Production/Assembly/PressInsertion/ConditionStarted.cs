/*
Copyright 2018 TE Connectivity

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
-------------------------------------------------------------------------
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;
using CFX.Structures;


namespace CFX.Production.Assembly.PressInsertion
{
    /// <summary>
    /// Sent by a press insertion machine when a condition has been started
    /// A condition is a physical or logical operation - i.e. A pin insertion or connector press onto a board
    /// is a physical condition, much like a validation of a part before a connector insertion occurs is a 
    /// logical condition
    /// 
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "UnitPosition": 
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT1",
    ///       "X": 0.254,
    ///       "Y": 0.556,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    /// }
    /// </code>
    /// </summary>
    public class ConditionCompleted : CFXMessage
    {
	/// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }
        /// <summary>
        /// Identifies the related production unit
        /// </summary>
	public UnitPosition UnitPosition
        {
            get;
            set;
        }
    }
}
