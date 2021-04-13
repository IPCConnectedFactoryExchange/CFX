﻿using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to block or disable a particular material setup location. 
    /// This is typically used where a loaded material may become unsuitable for use, 
    /// for example MSD expiry of an SMT material.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class BlockMaterialLocationsResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BlockMaterialLocationsResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
    }
}
