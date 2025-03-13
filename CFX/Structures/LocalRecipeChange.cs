using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Describe a local recipe change
    /// This is a dynamic structure.
    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class LocalRecipeChange
    {
        /// </summary>
        /// The type of local recipe change.
        /// </summary>
        public LocalRecipeChangeType Type
        {
            get;
            set;
        }

        /// <summary>
        /// The state of the local recipe change.
        /// </summary>
        public LocalRecipeChangeState State
        {
            get;
            set;
        }
    }
}
