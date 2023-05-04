using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes detailed information about a particular material package (instance of
    /// material that is tracked, stocked, and used within the factory environment.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialPackageDetail
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialPackageDetail()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Helper method which converts the more detailed MaterialPackageDetail structure
        /// to the simplified <see cref="MaterialPackage"/> structure.
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        /// <returns></returns>
        [CFX.Utilities.CreatedVersion("1.5")]
        public MaterialPackage ToMaterialPackage()
        {
            MaterialPackage p = new MaterialPackage()
            {
                UniqueIdentifier = this.UniqueIdentifier,
                InternalPartNumber = this.InternalPartNumber,
                Quantity = this.Quantity
            };

            return p;
        }

        /// <summary>
        /// The unique identifier of the material package
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The internal part number of the material contained within this material package
        /// </summary>
        public string InternalPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The internal package name of the material package
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        public string InternalPackageName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the manufacturer of this material
        /// </summary>
        public string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the original manufacturer of the material
        /// </summary>
        public string ManufacturerPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the supplier from whom the material was purchased / supplied.
        /// </summary>
        public string Vendor
        {
            get;
            set;
        }

        /// <summary>
        /// The part number of the material as it is known to the supplier or vendor of the material
        /// </summary>
        public string VendorPartNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The lot code applied to this batch of material by the original manufacturer of the material
        /// </summary>
        public string ManufacturerLotCode
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material package was introduced into the factory environment
        /// </summary>
        public DateTime? Created
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material was originally manufactured by the manufacturer
        /// </summary>
        public DateTime? ManufactureDate
        {
            get;
            set;
        }

        /// <summary>
        /// The date / time when this material was received into the factory
        /// </summary>
        public DateTime? ReceivedDate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the expiry date of this material package based on manufacture definitions.
        /// </summary>
        /// <value>The expiry date.</value>
        public DateTime? ExpiryDate
        {
            get;
            set;
        }

        

        /// <summary>
        /// The unit of measure for this material (items, liters, meters, grams, etc.)
        /// Only valid SI units of measure should be utilized
        /// </summary>
        public string Units
        {
            get;
            set;
        }

        /// <summary>
        /// The initial quantity of material contained within this material package at the time
        /// when it was initialized / introduced into the factory environment
        /// </summary>
        public double InitialQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// The quantity of material presently contained within this material package
        /// </summary>
        public double Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// The current status of this material package
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.None)]
        public MaterialStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies whether or not a material is hazardous, and if so, the regulatory directive that controls
        /// the use of this substance in production.
        /// </summary>
        public HazardousMaterialType HazardousMaterialType
        {
            get;
            set;
        }

        /// <summary>
        /// Optional dynamic structure containing specialized information about this material package.
        /// For example, if the material package contains moisture sensitive devices, this would contain
        /// additional information specific to MSD material handling (exposure time, etc.).
        /// </summary>
        public MaterialPackageData MaterialData
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
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        /// <value>The batch identifier.</value>
        [CFX.Utilities.CreatedVersion("1.5")]
        public string BatchId
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
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        /// <value>The grey zone.</value>
        [CFX.Utilities.CreatedVersion("1.5")]
        public double GreyZone
        {
            get;
            set;
        }

        /// <summary>
        /// The price of a part in the material package
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        public double PartPrice
        {
            get;
            set;
        }

        /// <summary>
        /// The unit of the price of a part in the material package
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        public string PartPriceUnit
        {
            get;
            set;
        }

        /// <summary>
        /// The unit of the price of a part in the material package
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        [JsonProperty(TypeNameHandling = TypeNameHandling.Auto)]
        public PackagingInfo PackagingInfo
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.7 **</para>
        /// The ResourceLocation on which the material is located (optional)
        /// If null, it is assumed that the Resource is the one associated to the source Endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.7")]
        public ResourceLocation ResourceLocation
        {
            get;
            set;
        }
    }
}
