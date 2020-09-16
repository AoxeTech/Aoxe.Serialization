using System;
using System.IO;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static void Serialize<T>(TextWriter textWriter, T t)
        {
            if (textWriter is null || t is null) return;
            XmlSerializer.Serialize<T>(textWriter, t);
        }

        public static void Serialize(Type type, TextWriter textWriter, object obj)
        {
            if (type is null || textWriter is null || obj is null) return;
            XmlSerializer.Serialize(type, textWriter, obj);
        }
    }
}