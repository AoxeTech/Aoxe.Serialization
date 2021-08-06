using System;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlHelper
    {
        public static byte[] Serialize<T>(T t) =>
            XmlSerializer.Serialize(t);
        
        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? Array.Empty<byte>() : XmlSerializer.Serialize(type, obj);
        
        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : XmlSerializer.Deserialize<T>(bytes);
        
        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty() ? type.GetDefaultValue() : XmlSerializer.Deserialize(type, bytes);
    }
}