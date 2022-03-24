using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// There is a certain workflow after the detection of a defective board. Usually a defective board has to be classified,
    /// i.e. an operator or process engineer has to confirm whether the inspection result is a real defect or a false fail (false call) error.
    /// The Verification Result is 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerificationResult
    {
        /// <summary>
        /// The defect which was detected is not classified
        /// </summary>
        NotVerifiedYet,
        /// <summary>
        /// The defect which was detected is confirmed 
        /// </summary>
        DefectConfirmed,
        /// <summary>
        /// The defect which was detected is rejected "FalseFail"
        /// </summary>
        DefectRejected,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// The defect which was detected is rejected "FalseFail", but corrective
        /// action for SMT process shall be initiated
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        DefectAccepted
    }
}