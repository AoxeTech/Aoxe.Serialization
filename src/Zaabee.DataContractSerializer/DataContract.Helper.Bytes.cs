using System;
using Zaabee.Extensions;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractHelper
    {
        public static byte[] Serialize<T>(T t) =>
            DataContractSerializer.Serialize(t);
        
        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? Array.Empty<byte>() : DataContractSerializer.Serialize(type, obj);
        
        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : DataContractSerializer.Deserialize<T>(bytes);
        
        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty() ? type.GetDefaultValue() : DataContractSerializer.Deserialize(type, bytes);
    }
}