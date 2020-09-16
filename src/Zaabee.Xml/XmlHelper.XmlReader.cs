using System;
using System.Xml;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static T Deserialize<T>(XmlReader xmlReader) =>
            xmlReader is null ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader) =>
            type is null || xmlReader is null ? null : XmlSerializer.Deserialize(type, xmlReader);
    }
}