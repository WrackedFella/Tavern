using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Tavern.Repository.Characters;

namespace Tavern.Ui.Json.Serialization
{
    /// <summary>
    /// Use this MetaValidatorConvertor with JsonConvert.SerializeObject to provide strictly meta validator information pertaining to this object. 
    /// Classes supported are any of the following type ValidationAttribute.
    /// 
    /// </summary>
    /// <remarks>
    /// Will provide
    /// </remarks>
    /// <example>
    /// JsonConvert.SerializeObject(object, Formatting.Indented, new CustomConverter())
    /// </example>
    public class MetaValidatorConverter : JsonConverter<CharacterModel>
    {
        public override CharacterModel ReadJson(JsonReader reader, Type objectType, CharacterModel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Our response to the Presenting just validator information to the end user.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, CharacterModel value, JsonSerializer serializer)
        {
            PropertyInfo[] props = value.GetType().GetProperties();
            bool attributesFound = false;
            foreach(var p in props)
            {
                var atts = p.GetCustomAttributes(typeof(ValidationAttribute));

                writer.WriteStartObject();

                foreach (var a in atts)
                {
                    if( attributesFound == false )
                    {
                        // start array.
                        attributesFound = true;
                    }

                    // shorthand for our fully qualified type name.
                    string fqTypeName = a.GetType().ToString();
                    writer.WritePropertyName(fqTypeName.Substring(fqTypeName.LastIndexOf(".")+1));

                    // get standard serialization of attribute object
                    writer.WriteValue(JsonConvert.SerializeObject(a)); //string attjson = JsonConvert.SerializeObject(a); // serializer.Serialize(writer, a)

                    // append to property as object data.
                    //writer.WriteRaw(attjson);

                    
                }

                if (attributesFound)
                {
                    writer.WriteEnd();
                    attributesFound = false;
                }
            }

            //writer.WriteEnd();

            // end array.
            writer.WriteEndObject();

        }
    }


    public class CharacterModelJsonSerializer
    {
    }
}
