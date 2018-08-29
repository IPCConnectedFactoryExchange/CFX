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
        ///  Describes the Operator who ran the condition step
        /// </summary>
        public Operator ConditionOperator
        {
            get;
            set;
        }//ConditionOperator
    }
}