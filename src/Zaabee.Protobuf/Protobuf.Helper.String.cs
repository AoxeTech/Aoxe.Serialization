using System;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufHelper
    {
        public static string SerializeToBase64<T>(T t) =>
            t is null
                ? string.Empty
                : ProtobufSerializer.SerializeToBase64(t);

        public static string SerializeToBase64(object obj) =>
            obj is null
                ? string.Empty
                : ProtobufSerializer.SerializeToBase64(obj);

        public static T DeserializeFromBase64<T>(string base64) =>
            base64.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : ProtobufSerializer.DeserializeFromBase64<T>(base64);

        public static object DeserializeFromBase64(Type type, string base64) =>
            base64.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : ProtobufSerializer.DeserializeFromBase64(type, base64);
    }
}