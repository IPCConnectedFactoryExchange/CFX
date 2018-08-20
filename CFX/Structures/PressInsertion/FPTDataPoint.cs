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
    /// Describes a force vs position vs time data point for a press.
    /// </summary>
    public class FPTDataPoint
    {
        public FPTDataPoint()
        {
        }
        /// <summary>
        /// The total force reading of the data point
        /// </summary>
        public double TotalForce
        {
            get;
            set;
        }
        /// <summary>
        /// The force reading of load cell A of the data point
        /// </summary>
        public double ForceA
        {
            get;
            set;
        }
        /// <summary>
        /// The force reading of load cell B the data point
        /// </summary>
        public double ForceB
        {
            get;
            set;
        }
        /// <summary>
        /// The position reading of the data point
        /// </summary>
        public double Position
        {
            get;
            set;
        }
        
	/// <summary>
        /// The time reading of the data point
        /// </summary>
        public double Time
        {
            get;
            set;
        }
    }
}