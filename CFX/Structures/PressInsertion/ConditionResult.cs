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

namespace CFX.Structures.PressInsertion
{
    /// <summary>
    /// Describes result of a condition step.
    /// </summary>
    public class ConditionResult
    {
        public ConditionResult()
        {
            ConditionBoardData = new BoardData();
            ConditionSequence = new Condition();
            Data = new ConditionData();
            ConditionOperator = new Operator();
        }

        /// <summary>
        ///  Data for board currently being processed
        /// </summary>
        public BoardData ConditionBoardData
        {
            get;
            set;
        }//ConditionBoardData

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
        public ConditionData Data
        {
            get;
            set;
        }//Data

        /// <summary>
        ///  Integer indicating where in the recipe sequence the condition occurs
        /// </summary>
        public uint SequenceNumber
        {
            get;
            set;
        }//SequenceNumber

        /// <summary>
        ///  The ID of the Machine used to complete the condition
        /// </summary>
        public string MachineID
        {
            get;
            set;
        }//MachineID

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