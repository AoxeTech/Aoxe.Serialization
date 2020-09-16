using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        private static readonly ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer> SerializerCache =
            new ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer>();

        public static string SerializeToXml<T>(T t, Encoding encoding) => SerializeToXml(typeof(T), t, encoding);

        public static string SerializeToXml(Type type, object obj, Encoding encoding)
        {
            using var ms = Pack(type, obj);
            return encoding.GetString(ms.ToArray());
        }

        public static T Deserialize<T>(string xml, Encoding encoding) =>
            (T) Deserialize(typeof(T), xml, encoding);

        public static object Deserialize(Type type, string xml, Encoding encoding)
        {
            using var ms = new MemoryStream(encoding.GetBytes(xml));
            return Unpack(type, ms);
        }

        private static System.Xml.Serialization.XmlSerializer GetSerializer(Type type) =>
            SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
    }
}