using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Zaabee.NewtonsoftJson
{
    internal class JsonContractResolver : DefaultContractResolver
    {
        private readonly IEnumerable<string> _props;
        private readonly bool _toLowerCamel;

        public JsonContractResolver(IEnumerable<string> props, bool toLowerCamel = false)
        {
            _props = props;
            _toLowerCamel = toLowerCamel;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            //自定义序列化字段，如果没有自定义或者特性规定强制转换的则返回全部，否则只返回自定义中存在的字段
            var lstProp = base.CreateProperties(type, memberSerialization);
            if (_props == null)
                return lstProp;
            var jsAttr = Attribute.GetCustomAttributes(type).OfType<JsonIgnoreAttribute>().FirstOrDefault();
            if (jsAttr != null && !jsAttr.Ignore)
                return lstProp;

            //只保留清单有列出的属性
            return lstProp.Where(p => !string.IsNullOrWhiteSpace(p.PropertyName) &&
                                      _props.Where(g => !string.IsNullOrWhiteSpace(g))
                                          .Any(g => g.Split(',')
                                              .Where(q => !string.IsNullOrWhiteSpace(q))
                                              .Select(q => q.ToUpper().Trim())
                                              .Contains(p.PropertyName.ToUpper().Trim()))).ToList();
        }

        protected override string ResolvePropertyName(string propertyName) =>
            _toLowerCamel ? GetCamelCaseName(propertyName) : propertyName;

        private static string GetCamelCaseName(string s)
        {
            if (string.IsNullOrEmpty(s) || char.IsLower(s[0]))
                return s;
            var chArray = s.ToCharArray();
            for (var i = 0; i < chArray.Length; i++)
            {
                var flag = (i + 1) < chArray.Length;
                if (i > 0 && flag && char.IsLower(chArray[i + 1]))
                    break;

                chArray[i] = char.ToLower(chArray[i], CultureInfo.InvariantCulture);
            }

            return new string(chArray);
        }
    }
}