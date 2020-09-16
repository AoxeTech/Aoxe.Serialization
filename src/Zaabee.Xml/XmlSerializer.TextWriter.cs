using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        public static void Serialize<T>(TextWriter textWriter, object obj) =>
            Serialize(typeof(T), textWriter, obj);

        public static void Serialize(Type type, TextWriter textWriter, object obj) =>
            GetSerializer(type).Serialize(textWriter, obj);
    }
}