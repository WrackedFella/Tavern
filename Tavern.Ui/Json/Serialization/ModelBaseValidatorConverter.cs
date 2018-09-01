using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using Shared;

namespace Tavern.Ui.Json.Serialization
{
	/// <summary>
	///
	/// Use this MetaValidatorConvertor with JsonConvert.SerializeObject to provide strictly meta validator information pertaining to this object.
	/// Classes supported are any of the following type ValidationAttribute.
	///
	/// </summary>
	/// <seealso cref="MetaValidatorConverter"/>
	/// <remarks>
	/// Will provide meta information or an empty object if type is of ModelBase. FOR OBJECTS OF THE TYPE ModelBase ONLY
	/// </remarks>
	/// <example>
	/// JsonConvert.SerializeObject(object, Formatting.Indented, new CustomConverter())
	/// </example>
	public class ModelBaseMetaValidatorConverter : JsonConverter<ModelBase>
	{
		public override ModelBase ReadJson(JsonReader reader, Type objectType, ModelBase existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Our response to Presenting just validator information to the end user.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		public override void WriteJson(JsonWriter writer, ModelBase value, JsonSerializer serializer)
		{
			PropertyInfo[] props = value.GetType().GetProperties();

			writer.WriteStartObject();

			foreach (var p in props)
			{
				var atts = p.GetCustomAttributes(typeof(ValidationAttribute));
				int attributeCount = atts.Count();
				if (attributeCount == 0)
					continue;

				string propertyName = p.Name;
				string propertyType = p.PropertyType.ToString().Replace("System.", "");

				// add info about what member is to be validated.
				writer.WritePropertyName(propertyName);
				writer.WriteStartObject();
				writer.WritePropertyName("DataType");
				writer.WriteValue(propertyType);

				writer.WritePropertyName("validators");
				writer.WriteStartObject();

				foreach (var a in atts)
				{
					// shorthand for our fully qualified type name.
					string fqTypeName = a.GetType().ToString();
					writer.WritePropertyName(fqTypeName.Substring(fqTypeName.LastIndexOf(".") + 1));

					// get standard serialization of attribute object
					string objout = JsonConvert.SerializeObject(a, new JsonSerializerSettings() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });

					// ignore "TypeId" member.
					int idx = objout.IndexOf(",\"TypeId\"");
					objout = objout.Remove(idx, (objout.IndexOf("\"", idx + 19) - idx) + 1);
					writer.WriteRawValue(objout);
				}

				writer.WriteEndObject();
				writer.WriteEndObject();
			}

			// end array of validators.
			writer.WriteEndObject();
		}
	}
}
