using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static void Serialize<T>(XmlWriter xmlWriter, T t) =>
            XmlSerializer.Serialize<T>(xmlWriter, t);

        public static void Serialize(Type type, XmlWriter xmlWriter, object obj) =>
            XmlSerializer.Serialize(type, xmlWriter, obj);
    }
}