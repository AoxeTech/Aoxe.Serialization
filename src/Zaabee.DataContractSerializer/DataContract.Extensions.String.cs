using System;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static T FromXml<T>(this string str) =>
            DataContractHelper.Deserialize<T>(str);

        public static object FromXml(this string str, Type type) =>
            DataContractHelper.Deserialize(type, str);
    }
}