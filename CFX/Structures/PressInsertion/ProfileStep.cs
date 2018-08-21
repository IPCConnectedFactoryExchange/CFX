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
    /// Describes a individual step of a Press Profile
    /// </summary>
    public class ProfileStep
    {
        /// <summary>
        /// The sequence position of this step in relation to the other steps in the profile.  Steps are peformed in increasing sequence integer order 1...n
        /// </summary>
        public int SequencePosition
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this step
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The speed of this step in mm/s.
        /// </summary>
        public double Speed
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the type of this step
        /// </summary>
        public StepType TypeOfStep
        {
            get;
            set;
        }

    }
}
