using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Tavern.Ui.Json.Serialization
{
	/// <summary>
	/// Use this MetaValidatorConvertor with JsonConvert.SerializeObject to provide strictly meta validator information pertaining to this object.
	/// Classes supported are any of the following type ValidationAttribute.
	///
	/// </summary>
	/// <remarks>
	/// Will provide Meta Information for the topic of validators for any object model.
	/// </remarks>
	/// <example>
	/// JsonConvert.SerializeObject(object, Formatting.Indented, new CustomConverter())
	/// </example>
	public class MetaValidatorConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Our response to Presenting just validator information to the end user.
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="serializer"></param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
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
