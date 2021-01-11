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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.PressInsertion
{
    /// <summary>
    /// Describes a Condition Sequence.  Conditions consist of one or more steps that control non-pressing actions for a press recipe.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Condition()
        {
            Steps = new ConditionStep[1];
        }

        /// <summary>
        /// The  name of the condition.
        /// </summary>
        public string ConditionName
        {
            get;
            set;
        }//ConditionName

        /// <summary>
        /// An array of the steps of the Condition.
        /// </summary>
        public ConditionStep[] Steps
        {
            get;
            set;
        }//Steps

        /// <summary>
        /// String containing the aggregated JavaScript code of all condition steps.
        /// </summary>
        public string JavaScriptCode
        {
            get;
            set;
        }//JavaScriptCode

        /// <summary>
        /// Indicates whether condition is a single step or consists of multiple sub-steps
        /// </summary>
        public Boolean MultiStep
        {
            get;
            set;
        }//MultiStep

    }//Condition
}
