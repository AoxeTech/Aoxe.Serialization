using System;
using System.Xml;
using Zaabee.Extensions;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractHelper
    {
        public static T Deserialize<T>(XmlReader xmlReader) =>
            xmlReader is null ? (T) typeof(T).GetDefaultValue() : DataContractSerializer.Deserialize<T>(xmlReader);

        public static object Deserialize(Type type, XmlReader xmlReader) =>
            type is null || xmlReader is null ? null : DataContractSerializer.Deserialize(type, xmlReader);
    }
}