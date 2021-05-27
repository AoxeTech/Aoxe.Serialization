using System;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtensions
    {
        public static T DeserializeFromBase64<T>(this string base64) =>
            MsgPackHelper.DeserializeFromBase64<T>(base64);

        public static object DeserializeFromBase64(this string base64, Type type) =>
            MsgPackHelper.DeserializeFromBase64(type, base64);
    }
}