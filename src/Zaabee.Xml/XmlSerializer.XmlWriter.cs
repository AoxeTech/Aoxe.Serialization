using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static void Serialize<T>(XmlWriter xmlWriter, object obj) =>
            Serialize(typeof(T), xmlWriter, obj);

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj) =>
            GetSerializer(type).Serialize(xmlWriter, obj);
    }
}