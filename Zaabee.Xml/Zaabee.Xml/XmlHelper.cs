using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Zaabee.Xml
{
    public static class XmlHelper
    {
        internal static string Serialize<T>(T t, Encoding encoding = null)
        {
            if (t == null) return string.Empty;
            encoding = encoding ?? Encoding.UTF8;
            using (var memoryStream = new MemoryStream())
            using (var xmlTextWriter = new XmlTextWriter(memoryStream, encoding))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(xmlTextWriter, t);
                memoryStream.Position = 0;
                using (var streamReader = new StreamReader(memoryStream, encoding))
                    return streamReader.ReadToEnd();
            }
        }

        internal static T Deserialize<T>(string xml, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default(T);
            encoding = encoding ?? Encoding.UTF8;
            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T) xmlSerializer.Deserialize(memoryStream);
            }
        }

        internal static object Deserialize(string xml, Type type, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml)) return null;
            encoding = encoding ?? Encoding.UTF8;
            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                var xmlSerializer = new XmlSerializer(type);
                return xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}