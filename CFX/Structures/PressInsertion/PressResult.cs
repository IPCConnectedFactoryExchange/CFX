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

namespace CFX.Structures.PressInsertion
{
    /// <summary>
    /// Describes result of a connector press.
    /// </summary>
    public class PressResult
    {
        public PressResult()
        {
            PressBoardData = new BoardData();
            PressConnector = new Connector();
            Data = new PressData();
            ConnectorLocation = new ConnectorCoordinates();
            PressOperator = new Operator();
        }

        /// <summary>
        ///  Data for board currently being processed
        /// </summary>
        public BoardData PressBoardData
        {
            get;
            set;
        }//PressBoardData

        /// <summary>
        ///  Connector that was pressed
        /// </summary>
        public Connector PressConnector
        {
            get;
            set;
        }//PressConnector

        /// <summary>
        ///  Data and status information about the results pressing cycle
        /// </summary>
        public PressData Data
        {
            get;
            set;
        }//Data


        /// <summary>
        ///  Location on PCB of connector that was pressed
        /// </summary>
        public ConnectorCoordinates ConnectorLocation
        {
            get;
            set;
        }//ConnectorLocation

        /// <summary>
        ///  Integer indicating where in the recipe sequence the press occurs
        /// </summary>
        public uint SequenceNumber
        {
            get;
            set;
        }//SequenceNumber

        /// <summary>
        ///  The ID of the Machine used to complete the press
        /// </summary>
        public string MachineID
        {
            get;
            set;
        }//MachineID

        /// <summary>
        ///  Describes the Operator who ran the press cycle (optional)
        /// </summary>
        public Operator PressOperator
        {
            get;
            set;
        }//PressOperator
    }
}