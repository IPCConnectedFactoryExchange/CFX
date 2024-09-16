using System.Collections.Generic;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Describes programmable tin feeder programs and included steps 
    /// </summary>
    public class FeederPrograms
    {
        /// <summary>
        /// Customizable
        /// </summary>
        public const int TOTAL_PROGRAMS = 5;
        /// <summary>
        /// Customizable number of length and speed appliable per program
        /// </summary>
        public const int STEPS_PER_PROGRAM = 3;

        /// <summary>
        /// a pair length of shipped tin and dm/s apllied deliver speed
        /// </summary>
        public class Step
        {
            /// <summary>
            /// decimeters
            /// </summary>
            public int length;
            /// <summary>
            /// decimeters per second
            /// </summary>
            public int speed;
        }
        /// <summary>
        /// abstracted list of steps
        /// </summary>
        public class Program
        {
            /// <summary>
            /// this program is Enabled or must be ignored
            /// </summary>
            public bool active;
            /// <summary>
            /// collection of actual program steps
            /// </summary>
            public List<Step> steps = new List<Step>();

            /// <summary>
            /// initialization
            /// </summary>
            public Program()
            {
                for (int j = 0; j < STEPS_PER_PROGRAM; j++)
                {
                    steps.Add(new Step());
                }
            }
        }
        /// <summary>
        /// collection of in soldering station stored programs
        /// </summary>
        public List<Program> programs;

        /// <summary>
        /// Collection of actual Station appliable programs. Station must have programmable tin deliverer
        /// </summary>

        IdentifySolderingStation StationIdentify;
        
        /// <summary>
        /// default constructor
        /// </summary>
        public FeederPrograms()
        {
            StationIdentify = new IdentifySolderingStation();

            programs = new List<Program>();

            //For ALE Station , 5 programs , 3 Steps each
            for (int i = 0; i < TOTAL_PROGRAMS; i++)
            {
                Program p = new Program();
                programs.Add(p);
            }
        }

    }
}
