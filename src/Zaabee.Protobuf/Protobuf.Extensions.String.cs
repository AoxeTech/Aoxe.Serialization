using System;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufExtensions
    {
        public static T DeserializeFromBase64<T>(this string text) =>
            ProtobufHelper.DeserializeFromBase64<T>(text);

        public static object DeserializeFromBase64(this string text, Type type) =>
            ProtobufHelper.DeserializeFromBase64(type, text);
    }
}