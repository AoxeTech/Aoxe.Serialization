using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Zaabee.NewtonsoftJson
{
    /// <inheritdoc />
    /// <summary>
    /// Json Contract Resolver
    /// </summary>
    internal class JsonContractResolver : DefaultContractResolver
    {
        private readonly IEnumerable<string> _props;
        private readonly bool _toLowerCamel;

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="props"></param>
        /// <param name="toLowerCamel"></param>
        public JsonContractResolver(IEnumerable<string> props, bool toLowerCamel = false)
        {
            //指定要序列化属性的清单
            _props = props;
            //是否转为小驼峰
            _toLowerCamel = toLowerCamel;
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates properties for the given <see cref="T:Newtonsoft.Json.Serialization.JsonContract" />.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
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

        /// <inheritdoc />
        /// <summary>
        /// Resolve Property Name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return _toLowerCamel ? GetCamelCaseName(propertyName) : propertyName;
        }

        /// <summary>
        /// To Camel Case
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
