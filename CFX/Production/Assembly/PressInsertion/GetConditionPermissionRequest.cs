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
using CFX.Structures.PressInsertion;


namespace CFX.Production.Assembly.PressInsertion
{
    /// <summary>
    /// This message is used to request a process endpoint for permission to proceed
    /// with the recipe based on the results of a condition sequence action
    /// <code language="none">
    /// {
    ///   "TransactionId": "7e712504-4d65-499f-9dcb-1974e20bae59",
    ///   "ConditionName" "Condition1",
    ///   "ConditionStep": {}
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
        /// Related Transaction ID specified previously by WorkStarted Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

	/// <summary>
        /// Identifies the Condition name
        /// </summary>
	public ConditionName ConditionName
	{
	    get;
	    set;
}	

	/// <summary>	
    	/// Describes a individual step of a Condition sequence that must be validated
	/// </summary>
	public ConditionStep ConditionStep
	{
	   get;
	   set;
	}
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
