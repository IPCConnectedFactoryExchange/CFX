using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a specific, single handling unit of a particular material, such as a reel of SMT parts,
    /// a bag of parts, bin of parts, etc.
    /// </summary>
    public class MaterialPackage
    {
        public MaterialPackage()
        {
        }

        /// <summary>
        /// The Unique identifier of the material package (barcode/RFID that identifies
        /// this specific material package.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the material package
        /// </summary>
        public string InternalPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of parts or material contained within this material package.
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }

 

        /// <summary>
        /// Gets or sets the next spliced material package.
        /// <remarks>
        /// When the placement machine is using tape material the operator can splice a new tape onto the existing material.
        /// This will lead to a chain of material. Physically the existing reel with the barcode will be separated from the
        /// already mounted tape and a new tape with its reel will be appended to the material. This leads to the situation that
        /// the material chain can only be identified by the newest material added to the chain (known as the "trailing" material package)
        /// using the barcode on its reel.  Typically the placement machine is consuming from the "leading" package of the chain.
        /// So the assumption is that we may build a chain B->A by splicing B to A, where A is the "leading"
        /// material package (consumed first), and B is the "trailing" material package (consumed last).  In this situation, the chain
        /// will be identified only by the barcode of B, and the MaterialPackage structure of B will have its LeadingMaterialPackage
        /// property set to A.  It should be noted that it is possible and permissible to form chains of more than 2 material packages.
        /// In this situation, each material package in the chain will have the LeadingMaterialPackage property set to the next package
        /// in the chain (with the exception of the material package that is currently being consumed (the "leading" material package).
        /// </remarks>
        /// </summary>
        /// <value>The next material package in the chain (heading towards the consumption point).</value>
        public MaterialPackage LeadingMaterialPackage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the batch identifier.
        /// <remarks>
        /// There is material in the factory where not each material unit is identifiable. This is the case for
        /// Trays for example. Trays are delivered as a batch of trays. But each tray does not have a unique ID, only
        /// the batch of trays has a unique ID.
        /// In this case, we assume that the unique Batch ID is in the property
        /// BatchID and each tray which is been mounted will get a temporary UniqueIdentifier as long as it is been
        /// mounted on the machine. See BatchMaterialPackage for more details.
        /// </remarks>
        /// </summary>
        /// <value>The batch identifier.</value>
        public string BatchId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the batch material package.
        /// <remarks>
        /// This field specify the parent batch material unit representing the complete batch.
        /// The BatchMaterialPackagecan be queried the quantity as well as other properties for the whole batch.
        ///  This data is only set, when the events are send out of the line level verification system. This
        ///  property can not be set via the interface. 
        /// </remarks>
        /// </summary>
        /// <value>The batch material package.</value>
        public MaterialPackage BatchMaterialPackage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the grey zone.
        /// <remarks>
        ///  This specifies the grey zone between 2 material packages. A grey zone is a zone
        ///     where the placement system can not determine where the switch between 2 material packages
        ///     has been taken place. Therefore the system tracks both material packages.
        ///     The quality of the GreyZone is driven by the process the customer is operating and if
        ///     the feeder are using optional splice sensor detectors or not.
        ///     Background is, that some sensors can detect the splice plate and the splice plate has a length
        /// which covers a number of components which hide the real end of tape. Therefore the verifcation system
        /// will report a greyzone between the "leading package" and the "trailing" in the chain.
        /// The greyzone will be maintained typically by the machine, based on the feeder configuration. When the feeder has a sploice sensor the
        /// grey zone will be calculated when the sensor detects the splice, and will be adjusted when components are consumed.
        /// When the greyzone reached zero, the "leading" package will be consumed and the chain will be modified by removing the "leading" package
        /// from the chain, resulting in the next package in the chain becoming the new "leading" package.
        /// </remarks>
        ///<summary>
        /// This sample scenarion explains the data change when consuming the material with a feeder with sensor:
        /// <list type="table">
        /// <listheader>
        /// <term>Action</term>
        /// <term>Description</term>
        /// <term>Resulting Chain</term>
        /// <term>Greyzone</term>
        /// </listheader>
        /// <item>
        /// <term>Inital</term>
        /// <term>Material with a defined quantity is mounted.</term>
        /// <term>A (100)</term>
        /// <term>0</term>
        /// </item>
        /// <item>
        /// <term>Production</term>
        /// <term>Material will be consumed during production (20 components).</term>
        /// <term>A (80)</term>
        /// <term>0</term>
        /// </item>
        /// <item>
        /// <term>Splicing</term>
        /// <term>New Material will be spliced to the mounted material.</term>
        /// <term>B(200) -> A (80)</term>
        /// <term>0</term>
        /// </item>
        /// <item>
        /// <term>Production</term>
        /// <term>Material will be consumed during production (50 components).</term>
        /// <term>B(200) -> A (30)</term>
        /// <term>0</term>
        /// </item>
        /// <item>
        /// <term>Splice detected</term>
        /// <term>Feeder detects the splice and calculated the grey zone (here 10) and adjust
        /// the quantity because sensor overrules filling level information.
        /// Event will be triggered, that a quantity correction has been performed. 
        /// </term>
        /// <term>B(200) -> A (0)</term>
        /// <term>10</term>
        /// </item>
        /// <item>
        /// <term>Production</term>
        /// <term>
        /// Material will be consumed during production (5 components).
        /// The material in the pickup location has a quantity of zero.
        /// The chain will be not be modified, because the greyzone is not zero.
        /// The material B will be consumed. 
        /// </term>
        /// <term>B(195) -> A(0)</term>
        /// <term>5</term>
        /// </item>        /// <item>
        /// <term>Production</term>
        /// <term>
        /// Material will be consumed during production ( components).
        /// The material in the pickup location has a quantity of zero.
        /// The chain will be modified, because the greyzone is zero.
        /// The material A will be consumed. An event will be send, that the
        /// mateiral A is been consumed. 
        /// </term>
        /// <term>B(190)</term>
        /// <term>0</term>
        /// </item>
        /// <item>
        /// <term>Production</term>
        /// <term>Material will be consumed during production (50 components).</term>
        /// <term>B(140) </term>
        /// <term>0</term>
        /// </item>
        /// </list>
        /// </summary>
        /// 
        /// </summary>
        /// <value>The grey zone.</value>
        public double GreyZone
        {
            get;
            set;
        }
    }
}
