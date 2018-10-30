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
    /// Describes a PCB that is being pressed.
    /// </summary>
    public class BoardData
    {
        public BoardData()
        {
        }

        /// <summary>
        /// The name of the board.
        /// </summary>
        public string BoardName
        {
            get;
            set;
        }//BoardName

        /// <summary>
        /// The board serial number
        /// </summary>
        public string SerialNumber
        {
            get;
            set;
        }//SerialNumber

        /// <summary>
        /// The board barcode label
        /// </summary>
        public string BarcodeLabel
        {
            get;
            set;
        }//BarcodeLabel

        /// <summary>
        /// The board start date
        /// </summary>
        public DateTime StartDateTime
        {
            get;
            set;
        }//StartDateTime   

        /// <summary>
        /// The board start time
        /// </summary>
        public DateTime EndDateTime
        {
            get;
            set;
        }//EndDateTime
    }
}