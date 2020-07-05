using System;
using System.IO;

namespace Zaabee.Xml
{
    public static class TextReaderExtension
    {
        public static T FromXml<T>(this TextReader textReader) =>
            XmlHelper.Deserialize<T>(textReader);

        public static object FromXml(this TextReader textReader, Type type) =>
            XmlHelper.Deserialize(type, textReader);
    }
}