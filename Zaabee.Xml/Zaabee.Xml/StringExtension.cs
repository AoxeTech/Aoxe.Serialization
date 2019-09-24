using System;
using System.Text;
using System.Threading.Tasks;

namespace Zaabee.Xml
{
    public static class StringExtension
    {
        public static T FromXml<T>(this string str, Encoding encoding = null) =>
            XmlHelper.Deserialize<T>(str, encoding);

        public static object FromXml(this string str, Type type, Encoding encoding = null) =>
            XmlHelper.Deserialize(type, str, encoding);

        public static async Task<T> FromXmlAsync<T>(this string str, Encoding encoding = null) =>
            await XmlHelper.DeserializeAsync<T>(str, encoding);

        public static async Task<object> FromXmlAsync(this string str, Type type, Encoding encoding = null) =>
            await XmlHelper.DeserializeAsync(type, str, encoding);
    }
}