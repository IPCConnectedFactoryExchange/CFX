using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.Utilities
{
    /// <summary>
    /// Utility helper class for converting numeric state codes to and from SEMI enumerations
    /// </summary>
    public static class StateConverter
    {
        /// <summary>
        /// Constant indicating the default ResourceState (if not defined).
        /// </summary>
        public const ResourceState DefaultResourceState = ResourceState.NST;

        /// <summary>
        /// Converts a semi state code to its E10 equivalent.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static ResourceState GetSemiE10State(ResourceState state)
        {
            ResourceState result = ResourceState.NST;
            int code = ((int)state / 1000) * 1000;

            result = (ResourceState)code;
            if (!System.Enum.IsDefined(typeof(ResourceState), result))
                result = ResourceState.NST;

            return result;
        }

        /// <summary>
        /// Converts a semi state code to its E10 equivalent.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static ResourceState GetSemiE58State(ResourceState state)
        {
            ResourceState result = ResourceState.NST;
            int code = ((int)state / 100) * 100;

            result = (ResourceState)code;
            if (!System.Enum.IsDefined(typeof(ResourceState), result))
                result = ResourceState.NST;

            return result;
        }
    }
}
