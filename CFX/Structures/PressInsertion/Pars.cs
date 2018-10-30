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
        /// A connector can be pressed with force that iproportional to the 
        /// actual resisting force detected during the pressing cycle.We call 
        /// this Percent Above Range Sample, or PARS.In this technique, 
        /// the connector’s resisting force while pressing is
        /// sampled and averaged over a distance range above final seating to 
        /// the board surface. The final force percent added assures complete 
        /// seating of the connector.This is the most widely used technique
        /// because it limits the stress to the assembly, but does not require 
        /// great accuracy for board thickness measurement.
        /// </summary>
    public class Pars
    {
        /// <summary>
        /// Gets or sets the percent above the sample range.
        /// </summary>
        public double PercentAbove
        {
            get;
            set;
        }//PercentAbove

        /// <summary>
        /// Gets or sets the start height in mm.
        /// </summary>
        /// <value>The start height.</value>

        public double StartHeight
        {
            get;
            set;
        }//Start Height

        /// <summary>
        /// Gets or sets the distance in mm
        /// </summary>
        /// <value>The distance.</value>
        public double Distance
        {
            get;
            set;
        }//Distance
    }//Pars
}
