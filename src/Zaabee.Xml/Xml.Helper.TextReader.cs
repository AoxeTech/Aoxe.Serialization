using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static T Deserialize<T>(TextReader textReader) =>
            textReader is null ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(textReader);

        public static object Deserialize(Type type, TextReader textReader) =>
            type is null || textReader is null ? null : XmlSerializer.Deserialize(type, textReader);
    }
}