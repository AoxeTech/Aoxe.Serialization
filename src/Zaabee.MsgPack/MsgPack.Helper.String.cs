using System;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static string SerializeToBase64<T>(T t) =>
            t is null
                ? string.Empty
                : MsgPackSerializer.SerializeToBase64(t);

        public static string SerializeToBase64(Type type, object obj) =>
            obj is null
                ? string.Empty
                : MsgPackSerializer.SerializeToBase64(type, obj);

        public static T DeserializeFromBase64<T>(string base64) =>
            base64.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : MsgPackSerializer.DeserializeFromBase64<T>(base64);

        public static object DeserializeFromBase64(Type type, string base64) =>
            base64.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : MsgPackSerializer.DeserializeFromBase64(type, base64);
    }
}