using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlExtension
    {
        public static T ReadXml<T>(this TextReader textReader) =>
            XmlHelper.Deserialize<T>(textReader);

        public static object ReadXml(this TextReader textReader, Type type) =>
            XmlHelper.Deserialize(type, textReader);
    }
}