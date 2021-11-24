using System;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractHelper
    {
        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null || stream is null) return;
            DataContractSerializer.Pack(t, stream);
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (type is null || obj is null || stream is null) return;
            DataContractSerializer.Pack(type, obj, stream);
        }
        
        public static MemoryStream Pack<T>(T t) =>
            t is null ? new MemoryStream() : DataContractSerializer.Pack(t);
        
        public static MemoryStream Pack(Type type, object obj) =>
            obj is null ? new MemoryStream() : DataContractSerializer.Pack(type, obj);
        
        public static T? Unpack<T>(Stream stream) =>
            stream.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : DataContractSerializer.Unpack<T>(stream);
        
        public static object Unpack(Type type, Stream stream) =>
            stream.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : DataContractSerializer.Unpack(type, stream);
    }
}