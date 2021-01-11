using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace CFX.Structures.PCBInspection
{

    /// <summary>
    /// A board typically is part of a (multi-)panel and may contain fiducials, components
    /// (an even sub-boards).
    /// It is an inspection object itself, too (with features on its own).
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Board : GeometricObject
    {
        /// <summary>
        /// This is a list of fiducials.
        /// </summary>
        [JsonProperty(Order = 1)] // The children should come at the end.
        public List<Fiducial> Fiducials { get; set; }

        /// <summary>
        /// This is the list of components in the board definition.
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<Component> Components { get; set; }

        /// <summary> 
        /// List of "sub-boards" of this board.
        /// Usually empty, but it allows to have panels with several boards, where each board may have some "sub-boards", even recursivly. 
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<Board> Boards;


        /// <summary>
        /// A board is considered defect if there is a defect in (the features / checks of) the board itself
        /// or in one of its components, fiducials, or sub-boards.
        /// </summary>
        [JsonIgnore] // A calculated property, so no need to serialize and transmit it.
        public override bool IsDefect
        {
            get
            {
                if (IsRepaired)
                    return false;  // The board as a whole was repaired, so it is not defective anymore.

                if (base.IsDefect)
                    return true;  // The board itself is defective.

                // Check all children recursively.

                foreach (Fiducial fiducial in Fiducials ?? Enumerable.Empty<Fiducial>())
                {
                    if (fiducial.IsDefect)
                        return true; // At least one fiducial is defective, so this board is considered defective.
                }

                foreach (Component component in Components ?? Enumerable.Empty<Component>())
                {
                    if (component.IsDefect)
                        return true; // At least one component is defective, so this board is considered defective.
                }

                foreach (Board board in Boards ?? Enumerable.Empty<Board>())
                {
                    if (board.IsDefect)
                        return true; // At least one board is defective, so this board is considered defective.
                }

                return false; // No defect in any of our features or children.
            }
        }


        /// <summary> Restrict serialization to avoid confusion. </summary>
        public bool ShouldSerializeBoards()
        {
            return ((Boards != null) && (Boards.Count > 0));
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public int? UnitPositionNumber
        {
            get;
            set;
        }

    }
}
