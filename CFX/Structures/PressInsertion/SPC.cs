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
    /// Statistial Process Control parameters for the pressing operation.
    /// </summary>
    public class SPC
    {
        /// <summary>
        /// Gets or sets the distance from the board when SPC will be initiated
        /// </summary>
        public double StartDistance
        {
            get;
            set;
        }//StartDistance

        /// <summary>
        /// Gets or sets the start height.
        /// </summary>
        /// <value>The start height.</value>
        public double StartHeight
        {
            get;
            set;
        }//StartHeight
        /// <summary>
        /// Gets or sets the minimum force limit per pin (N/pin).
        /// </summary>
        /// <value>The minimum force.</value>
        public double MinimumForceLimit
        {
            get;
            set;
        }//MinimumForceLimit

        /// <summary>
        /// Gets or sets the maximum force limit per pin (N/pin)
        /// </summary>
        /// <value>The maximum force limit.</value>
        public double MaximumForceLimit
        {
            get;
            set;
        }
       
    }//SPC
}
