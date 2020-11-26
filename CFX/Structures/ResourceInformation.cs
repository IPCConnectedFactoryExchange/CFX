﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic structure that contains information related to the resources / sub-resources in an Endpoint.
    /// It may be used to model, among the others: camera, conveyor, gantries and other 
    /// parts that may require traceable operations (i.e. maintenance)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ResourceInformation
    {
        /// <summary>
        /// Name of the resource / sub-resource in the endpoint
        /// </summary>
        [JsonProperty(Order = -2)]
        public string ResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// The internal identifier (if applicable) of the part that is installed at this position.
        /// </summary>
        [JsonProperty(Order = -3)]
        public string ResourceIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// An enumeration indicating the type of unique identifier for the specified resource
        /// Values: GloballyPersistent, LocallyPersistent, UnserializedLocation or Unknown
        /// </summary>
        [JsonProperty(Order = -3)]
        public IdentiferUniquenessType IdentiferUniqueness    
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the part that is installed at this position.
        /// </summary>
        [JsonProperty(Order = -2)]
        public string ResourceType
        {
            get;
            set;
        }

        /// <summary>
        /// The position where the required part is installed on the Endpoint (optional). 
        /// Where applicable, a dot (".") notation should be utilized to designate specific positions.
        /// Examples: MODULE1.BEAM1.HEADPOS2, MODULE1.NEST3.NOZZLESLOT4, etc.
        /// </summary>
        [JsonProperty(Order = -2)]
        public string ResourcePosition
        {
            get;
            set;
        }

        /// <summary>
        /// The maintenance status for this resource
        /// </summary>
        [JsonProperty(Order = -2)]
        public MaintenanceStatus MaintenanceStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Optional:In case a nonstandard additional resource shall be modelled.
        /// This list gives the flexibility of modelling objects which are not explicitly specified in the model.
        /// The recommendation is to use this field only in case of unknown resource types 
        /// </summary>
        [JsonProperty(Order = -2)]
        public List<ResourceInformation> AdditionalSubResources
        {
            get;
            set;
        }

    }
}
