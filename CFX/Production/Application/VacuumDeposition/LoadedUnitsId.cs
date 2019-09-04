using System;
using System.Collections.Generic;
using CFX.Structures;

namespace CFX.Production.Application.VaccumDeposition
{
    /// <summary>
    /// Provides information about production units loaded.
    /// <code language="none">
    /// {
    ///     "TransactionID":"2ed629ea-ef8b-47df-9c11-abbdbe8d6b4e",
    ///     "UnitCount":3,
    ///     "Unit_Id":[
    ///     {
    ///         "AssyPN":"7005023A",
    ///         "ECRL":"AA",
    ///         "Rev":"A",
    ///         "Side":"B",
    ///         "UnitIdentifier":"12345",
    ///         "WorkOrder":"123456789"
    ///     },
    ///     {
    ///         "AssyPN":"7005023A",
    ///         "ECRL":"AA",
    ///         "Rev":"A",
    ///         "Side":"B",
    ///         "UnitIdentifier":"12345",
    ///         "WorkOrder":"123456789"
    ///     },
    ///     {
    ///         "AssyPN":"7005023A",
    ///         "ECRL":"AA",
    ///         "Rev":"A",
    ///         "Side":"B",
    ///         "UnitIdentifier":"12345",
    ///         "WorkOrder":"123456789"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    //////////////////////////////////////////////////////////////////////

    public class LoadedUnitsId : CFXMessage
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public LoadedUnitsId()
        {
            TransactionID = Guid.NewGuid();
            Unit_Id = new List<UnitId>();
        }

        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message.
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// Number of units in batch.
        /// </summary>
        public int UnitCount
        {
            get
            {
                return Unit_Id.Count;
            }
            private set
            {
            }
        }

        /// <summary>
        /// Data that identifies all production units.
        /// </summary>
        public List<UnitId> Unit_Id
        {
            get;
            set;
        }
    }
}
