using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static T Deserialize<T>(XmlReader xmlReader) => (T) Deserialize(typeof(T), xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader) =>
            GetSerializer(type).Deserialize(xmlReader);
    }
}