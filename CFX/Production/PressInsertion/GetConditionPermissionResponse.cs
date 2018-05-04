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

namespace CFX.Production.PressInsertion
{
    /// <summary>
    /// This message is used to grant or reject permission for a process endpoint to proceed
    /// with the recipe based on the results of a condition sequence action.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "RecipeName": "RECIPE3234",
    ///   "SequenceNumber": 2,
    ///   "ConditionName": "ValidateSerialNumber"
    /// }
    /// </code>
    /// </summary>
    public class GetConditionPermissionResponse : CFXMessage
    {
        public GetConditionPermissionResponse()
        {
            Result = new RequestResult();
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
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }//RequestResult
    }
}
