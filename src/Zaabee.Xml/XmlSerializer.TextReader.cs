using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static T Deserialize<T>(TextReader textReader) =>
            (T) Deserialize(typeof(T), textReader);

        public static object Deserialize(Type type, TextReader textReader) =>
            GetSerializer(type).Deserialize(textReader);
    }
}