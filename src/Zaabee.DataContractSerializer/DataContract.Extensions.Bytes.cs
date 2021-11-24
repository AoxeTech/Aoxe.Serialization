using System;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractExtensions
    {
        public static T FromBytes<T>(this byte[] bytes) => DataContractHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) => DataContractHelper.Deserialize(type, bytes);
    }
}