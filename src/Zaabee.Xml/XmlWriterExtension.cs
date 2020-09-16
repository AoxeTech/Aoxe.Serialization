using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static class XmlWriterExtension
    {
        public static void WriteXml<T>(this XmlWriter xmlWriter, T t) =>
            XmlHelper.Serialize<T>(xmlWriter, t);

        public static void WriteXml(this XmlWriter xmlWriter, Type type, object obj) =>
            XmlHelper.Serialize(type, xmlWriter, obj);
    }
}