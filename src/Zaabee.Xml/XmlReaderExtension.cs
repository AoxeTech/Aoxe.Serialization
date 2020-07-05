using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static class XmlReaderExtension
    {
        public static T FromXml<T>(this XmlReader xmlReader) =>
            XmlHelper.Deserialize<T>(xmlReader);

        public static object FromXml(this XmlReader xmlReader, Type type) =>
            XmlHelper.Deserialize(type, xmlReader);
    }
}