using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlExtensions
    {
        public static void WriteXml<T>(this XmlWriter xmlWriter, T t) =>
            XmlHelper.Serialize(xmlWriter, t);

        public static void WriteXml(this XmlWriter xmlWriter, Type type, object obj) =>
            XmlHelper.Serialize(type, xmlWriter, obj);
    }
}