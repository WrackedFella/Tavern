using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Tavern.Ui.Core
{
	public class RenderDataContractResolver : CamelCasePropertyNamesContractResolver
	{
		public RenderDataContractResolver()
		{
		}

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			var property = base.CreateProperty(member, memberSerialization);
			if (property.Converter == null)
			{
				//var attr = property.AttributeProvider.GetAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>()
				//	.FirstOrDefault(a => !string.IsNullOrEmpty(a.DisplayName));
				//if (attr != null)
				//{
				//	property.Converter = new DisplayNameConverter(attr.DisplayName);
				//}
				var attrNames = new List<string>();
				foreach (var attr in property.AttributeProvider.GetAttributes(true).ToList())
				{
					attrNames.Add(attr.GetType().Name);
				}

				var test = property.GetType().Name;
				property.Converter = new MetaDataConverter(attrNames);
			}

			return property;
		}
	}
	
	public class MetaDataConverter : JsonConverter
	{
		public override bool CanRead => false;
		public List<string> AttributeNames { get; set; }

		public MetaDataConverter(List<string> attributeNames)
		{
			this.AttributeNames = attributeNames;
		}

		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException(); // Not called when applied directly to a property.
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var jvalue = JToken.FromObject(value);
			if (jvalue.Type == JTokenType.Null)
			{
				jvalue.WriteTo(writer);
			}
			else
			{
				var customValue = new {
					value,
					attributes = this.AttributeNames.Join(", ")
				};
#if DEBUG
                writer.WriteValue(JsonConvert.SerializeObject(customValue, Formatting.Indented));
#else
                writer.WriteValue(JsonConvert.SerializeObject(customValue, Formatting.None));
#endif
            }

            //writer.WriteValue(jvalue + this.DisplayNamesPostfix);
        }
	}
}
