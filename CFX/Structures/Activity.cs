using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Dynamic structure base class.  Describes an activity that was performed in the course of processing one or more
    /// production units.  Different endpoints may produce more specific structures derived from this generic Activity structure.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Activity()
        {
            ActivityInstanceId = Guid.NewGuid();
            ActivityState = ActivityState.Completed;
            TimeStamp = DateTime.Now;
        }

        /// <summary>
        /// The time when the activity transitioned to the state specified by the
        /// ActivityState property.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// An id uniquely identfying a particular instance of an activity.  If the same activity occurs x times, each
        /// instance shall have a unique identifier.
        /// </summary>
        public Guid ActivityInstanceId
        {
            get;
            set;
        }

        /// <summary>
        /// The current state of the activity (started, completed, etc.).
        /// </summary>
        public ActivityState ActivityState
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the activity.
        /// </summary>
        public string ActivityName
        {
            get;
            set;
        }

        /// <summary>
        /// Optional free-form comments associated with the activity.
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration describing the value-add nature of an activity or process.
        /// </summary>
        public ValueAddType ValueAddType
        {
            get;
            set;
        }
    }
}
