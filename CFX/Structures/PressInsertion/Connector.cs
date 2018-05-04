/*
Copyright 2018 TE Connectivity

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
-------------------------------------------------------------------------
*/
﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.PressInsertion
{
    /// <summary>
    /// Describes a Pressed Connector
    /// </summary>
    public class Connector : ComponentDesignator
    {
        public Connector()
        {
            ConnectorTool = new PressTool();
            ProfileApplied = new PressProfile();
            ConnectorImage = new Image();
            Forces = new ConnectorForces();
            ManufacturerData = new Manufacturer();
            ParsSetting = new Pars();
            SPCSetting = new SPC();
        }
        
        /// <summary>
        /// Tool used to press this connector
        /// </summary>
        public PressTool ConnectorTool
        {
            get;
            set;
        }//ConnectorTool

        /// <summary>
        /// Profile used to press this connector
        /// </summary>
        public PressProfile ProfileApplied
        {
            get;
            set;
        }//ProfileApplied

        /// <summary>
        /// The number of pins on this connector
        /// </summary>
        public int PinCount
        {
            get;
            set;
        }

        /// <summary>
        /// The image of this connector
        /// </summary>
        public Image ConnectorImage
        {
            get;
            set;
        }
        /// <summary>
        /// The dimesion of the top of the connector from the top of the board when the connector is not seated
        /// </summary>
        public double UnseatedTop
        {
            get;
            set;
        }
        /// <summary>
        /// The dimesion of the top of the connector from the top of the board when the connector is seated
        /// </summary>
        public double SeatedHeight
        {
            get;
            set;
        }
        /// <summary>
        /// The thickness of the connector 
        /// </summary>
        public double BaseThickness
        {
            get;
            set;
        }
        /// <summary>
        ///  Value to signfiy if the connector requires flatrock tooling (tooling that does not have openings for the pins)
        /// </summary>
        public Boolean FlatrockTooling
        {
            get;
            set;
        }
        /// <summary>
        ///  Value to signfiy if the connector requires flatrock tooling (tooling that does not have openings for the pins)
        /// </summary>

        /// <summary>
        ///  Connector force definitions
        /// </summary>
        public ConnectorForces Forces 
        {
            get;
            set;
        }

        /// <summary>
        ///  Manufactuer of the connector
        /// </summary>
        public Manufacturer ManufacturerData
        {
            get;
            set;
        }

        /// <summary>
        ///  Group identifier of the connector
        /// </summary>
        public string Group
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the pars setting.
        /// </summary>
        /// <value>The pars setting.</value>
        public Pars ParsSetting
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the SPC setting.
        /// </summary>
        /// <value>The SPC setting.</value>
        public SPC SPCSetting
        {
            get;
            set;
        }

    }//Connector
}
