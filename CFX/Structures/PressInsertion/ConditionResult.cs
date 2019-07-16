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
using System.Text;
using CFX.Structures;

namespace CFX.Structures.PressInsertion
{
    /// <summary>
    /// Describes result of a condition step.
    /// </summary>
    public class ConditionResult
    {
        public ConditionResult()
        {
	    TransactionID = Guid.NewGuid();	
            Units = new List<UnitPosition>();
        
            ConditionSequence = new Condition();
	        ConditionStatus =new StatusResult();
            ConditionOperator = new Operator();
        }

        /// <summary>
        /// The barcode, RFID, etc. that was most recently acquired by the scanner / reader.  If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes BoardId of the carrier, a PCB panel or single production unit. If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// HermesIdentifier will be transfered between all machines which support Hermes. The PrimaryIdentifier is containing a barcode information.
        /// Both can be transferred.
        /// <remarks>
        /// Espcially when the line does not support the Hermes standard in the hole line, the Hermes Identifier can be unique only in the a part
        /// of the line. The Primary Identifier can be used to correlate the parts of hermes sublines to correlate this data as well. 
        /// </remarks>
        /// </summary>
        public string HermesIdentifier 
        {
            get;
            set;
        }


        /// <summary>
        /// Transaction ID used to attach events and data during subsequent processing, until WorkCompleted
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }
        
	/// <summary>
        /// Data that identifies each specific instance of production unit with a carrier or panel. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }

        /// <summary>
        ///  Describes Condition sequence that was executed
        /// </summary>
        public Condition ConditionSequence
        {
            get;
            set;
        }//ConditionSequence

        /// <summary>
        ///  Describes result of the condition sequence
        /// </summary>
        public StatusResult ConditionStatus
        {
            get;
            set;
        }///ConditionStatus

        /// <summary>
        ///  Describes the Operator who ran the condition step (optional)
        /// </summary>
        public Operator ConditionOperator
        {
            get;
            set;
        }//ConditionOperator
    }
}