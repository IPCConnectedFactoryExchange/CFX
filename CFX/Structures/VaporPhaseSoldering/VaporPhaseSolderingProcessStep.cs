using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.VaporPhaseSoldering
{
    /// <summary>
    /// Vapor Phase Soldering Process Step
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class VaporPhaseSolderingProcessStep
    {
        public int StepNumber //1,2,3,4,5....30
        { 
            get; 
            set; 
        }

        public string StepName //4,3,1,2,
        { 
            get; 
            set; 
        }

        public VaporPhaseSolderingProcessStepType StepType 
        {
            get;
            set;
        }

        public VaporPhaseSolderingProcessStepState StepState 
        { 
            get; 
            set; 
        }
    }
}
