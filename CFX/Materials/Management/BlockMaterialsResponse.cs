using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Response to a request block one or more instances of material from use in production
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "MaterialsPackagesNotBlocked": []
    /// }
    /// </code>
    /// </summary>
    public class BlockMaterialsResponse : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BlockMaterialsResponse()
        {
            Result = new RequestResult();
            MaterialsPackagesNotBlocked = new List<string>();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// In the case that some of the material packages identified in the request could not be blocked,
        /// the Result property will be set to PartialSuccess, and this property will contain a list of the identifiers
        /// that could not be blocked.
        /// </summary>
        public List<string> MaterialsPackagesNotBlocked
        {
            get;
            set;
        }
    }
}
