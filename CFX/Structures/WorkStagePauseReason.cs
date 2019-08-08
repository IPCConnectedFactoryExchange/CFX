using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of WorkStage pause reasons
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WorkStagePauseReason
    {
        /// <summary>
        /// The reason of the pause is unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// The stage is stopped because a material is missing (or too low quantity) for production
        /// </summary>
        MaterialMissing,
        /// <summary>
        /// The stage is stopped because a nozzle is missing (or too low quantity) for production
        /// </summary>
        NozzleMissing,
        /// <summary>
        /// The stage is waiting for the previous stage ton convey a board to him
        /// </summary>
        WaitingForPreviousStageConveying,
        /// <summary>
        /// The stage is waiting for the next stage to be able to receive a board
        /// </summary>
        WaitingForNextStageConveying,
        /// <summary>
        /// The stage is waiting for the operator to execute a manual alignment
        /// </summary>
        ManualAlignmentNeeded,
        /// <summary>
        /// The stage is waiting for the operator to confirm the installation a material (doubt)
        /// </summary>
        MaterialInstalledConfirmationNeeded,
        /// <summary>
        /// The stage is waiting for the operator to manually fill a barcode
        /// </summary>
        ManualBarcodeFillingNeeded,
        /// <summary>
        /// The stage is waiting for the operator to confirm an information message
        /// </summary>
        InformationMessageConfirmation,
    }
}
