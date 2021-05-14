using System;
using System.Xml;

namespace Zaabee.Xml
{
    public static partial class XmlExtensions
    {
        public static T ReadXml<T>(this XmlReader xmlReader) =>
            XmlHelper.Deserialize<T>(xmlReader);

        public static object ReadXml(this XmlReader xmlReader, Type type) =>
            XmlHelper.Deserialize(type, xmlReader);
    }
}