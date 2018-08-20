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
    /// Describes various data pertaining the result of a press.
    /// </summary>
    public class PressData
    {
        public PressData()
        {
        }

        /// <summary>
        ///  Status indicating how the press terminated
        /// </summary>
        public string Status
        {
            get;
            set;
        }//Status

        /// <summary>
        ///  Describes the force or height measurement which caused the press to terminate
        /// </summary>
        public string TerminationMeasurement
        {
            get;
            set;
        }//TerminationMeasurement

        /// <summary>
        ///  The average force measured over the SPC position range
        /// </summary>
        public double SPCAverageForce
        {
            get;
            set;
        }//SPCAverageForce

        /// <summary>
        ///  The height at which max pressing force was achieved
        /// </summary>
        public double HeightAtMaxForce
        {
            get;
            set;
        }//HeightAtMaxForce

        /// <summary>
        ///  The max force achieved during the press
        /// </summary>
        public double MaxForce
        {
            get;
            set;
        }//MaxForce

        /// <summary>
        ///  The height at which the press terminated
        /// </summary>
        public double TerminationHeight
        {
            get;
            set;
        }//TerminationHeight

        /// <summary>
        ///  The force at which the press terminated
        /// </summary>
        public double TerminationForce
        {
            get;
            set;
        }//TerminationForce
    }
}