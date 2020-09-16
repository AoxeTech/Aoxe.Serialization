using System;
using System.Text;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static string SerializeToXml<T>(T t, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(t, encoding ?? DefaultEncoding);

        public static string SerializeToXml(Type type, object obj, Encoding encoding = null) =>
            XmlSerializer.SerializeToXml(type, obj, encoding ?? DefaultEncoding);

        public static T Deserialize<T>(string xml, Encoding encoding = null) =>
            xml.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : XmlSerializer.Deserialize<T>(xml, encoding ?? DefaultEncoding);

        public static object Deserialize(Type type, string xml, Encoding encoding = null) =>
            type is null || xml.IsNullOrWhiteSpace()
                ? null
                : XmlSerializer.Deserialize(type, xml, encoding ?? DefaultEncoding);
    }
}