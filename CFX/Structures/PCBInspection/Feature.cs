using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace CFX.Structures.PCBInspection
{

    /// <summary>
    /// A feature/charcteristic/property/attribute (of a panel, board, componemnt, etc.) to check.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Feature : NamedObject
    {
        /// <summary>
        /// The feature is out of its allowed limits, so it is assumed to be a defect.
        /// But a defect detected during inspection may have been identified as a "false call" in verification
        /// or may have been repaired.
        /// </summary>
        [JsonIgnore]
        public bool IsDefect
        {
            get
            {
                if (IsRepaired)
                    return false;  // Feature was repaired successfully, so not a defect anymore.

                if (IsVerified)               // The verification (by a human) has
                    return IsVerifiedDefect;  // either confirmed the defect or has corrected the inspection result (i.e. it was a "false call").

                if (IsInspected.HasValue && !IsInspected.Value)
                    return true;   // This feature was not inspected/checked at all, as a precaution it is rated like a defect.

                return IsDetectedDefect;   // The (automatic) inspection may have detected a defect.
            }
        }


        /// <summary>
        /// This feature was checked.
        /// (The inspection may have been skipped due to a defect detected earlier, so further
        /// time consuming inspections are pointless.)
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(true)]  // Special default for serialization.
        public bool? IsInspected { get; set; }

        /// <summary>
        /// The inspection has detected/classified this feature as defect.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDetectedDefect { get; set; } = false;


        /// <summary>
        /// This (usually defective) feature was verified (AKA "classified") by a human.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsVerified { get; set; } = false;

        /// <summary>
        /// The verification (AKA "classification") by a human has confirmed a defect.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsVerifiedDefect { get; set; } = false;


        /// <summary>
        /// The (eventual) defect was repaired successfully.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsRepaired { get; set; } = false;


        /// <summary>
        /// It is cleaner to have several subclasses with specific value type (float and int in
        /// addition to string).
        /// </summary>
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Value.Converter))]
        public class Value : NamedObject
        {
            /// <summary>
            /// The name of the unit for this value.
            /// </summary>
            public string Unit { get; set; }


            // CHECK: Is this converter really necessary?

            /// <summary>
            /// A custom Feature.Value-converter to correctly deserialize all its different subclasses 
            /// (i.e. StringValue, FloatValue, and IntValue).
            /// </summary>
            class Converter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(Value);
                }

                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    JToken jFeatureValue = JToken.Load(reader);
                    JToken jValue = jFeatureValue["Value"];
                    Value featureValue = null;

                    // Depending on the type of the member "Value" a different subclass of Feature.Value is created.
                    if (jValue.Type == JTokenType.Float)
                    {
                        featureValue = new FloatValue()
                        {
                            Value = jValue.ToObject<double>(),
                        };
                    }
                    else if (jValue.Type == JTokenType.Integer)
                    {
                        featureValue = new IntValue()
                        {
                            Value = jValue.ToObject<Int64>(),
                        };
                    }
                    else /*if (jValue.Type == JTokenType.String)*/
                    {
                        featureValue = new StringValue()
                        {
                            Value = jValue.ToObject<String>(),
                        };
                    }

                    // The members Name and Unit are the same for all subclasses.
                    featureValue.Name = jFeatureValue["Name"].ToObject<String>();
                    featureValue.Unit = jFeatureValue["Unit"]?.ToObject<String>();  // Unit may be null

                    return featureValue;
                }

                // For writing the default serialization is used.
                public override bool CanWrite
                {
                    get
                    {
                        return false;
                    }
                }
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Representation of a string value.
        /// </summary>
        public class StringValue : Value
        {
            /// <summary>
            /// A string value.
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        /// Representation of a float value.
        /// </summary>
        public class FloatValue : Value
        {
            /// <summary>
            /// A float value.
            /// </summary>
            public double Value { get; set; }
        }

        /// <summary>
        /// Representation of an integer value.
        /// </summary>
        public class IntValue : Value
        {
            /// <summary>
            /// An integer value.
            /// </summary>
            public Int64 Value { get; set; }
        }

        /// <summary>
        /// List of values (of varying types).
        /// </summary>
        public List<Value> Values { get; set; }
    }

}
