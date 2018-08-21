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

namespace CFX.Production.PressInsertion
{
    /// <summary>
    /// This message is used to request a process endpoint for permission to proceed
    /// with the recipe based on the results of a condition sequence action
    /// <code language="none">
    /// {
    ///   "RecipeName": "RECIPE3234",
    ///   "SequenceNumber": 2,
    ///   "ConditionName": "ValidateSerialNumber",
    ///   "Data": {}
    /// }
    /// </code>
    /// </summary>
    public class GetConditionPermissionRequest : CFXMessage
    {

        public GetConditionPermissionRequest()
        {
        }

        /// <summary>
        /// The name of the current recipe being processed
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }//RecipeName

        /// <summary>
        ///  Integer indicating where in the recipe sequence the requesting condition occurs
        /// </summary>
        public uint SequenceNumber
        {
            get;
            set;
        }//SequenceNumber

        /// <summary>
        /// The name of the condition requesting permission
        /// </summary>
        public string ConditionName
        {
            get;
            set;
        }//ConditionName

        /// <summary>
        /// The data to validate
        /// </summary>
        public string Data
        {
            get;
            set;
        }//Data
    }
}
