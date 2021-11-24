using System;
using Zaabee.Extensions;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractHelper
    {
        public static string SerializeToXml<T>(T t) =>
            DataContractSerializer.SerializeToXml(t);

        public static string SerializeToXml(Type type, object obj) =>
            DataContractSerializer.SerializeToXml(type, obj);

        public static T Deserialize<T>(string xml) =>
            xml.IsNullOrWhiteSpace()
                ? (T) typeof(T).GetDefaultValue()
                : DataContractSerializer.Deserialize<T>(xml);

        public static object Deserialize(Type type, string xml) =>
            type is null || xml.IsNullOrWhiteSpace()
                ? null
                : DataContractSerializer.Deserialize(type, xml);
    }
}