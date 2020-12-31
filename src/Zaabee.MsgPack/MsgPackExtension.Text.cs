using System;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtension
    {
        public static T FromBase64<T>(this string base64) =>
            MsgPackHelper.DeserializeFromBase64<T>(base64);

        public static object FromBase64(this string base64, Type type) =>
            MsgPackHelper.DeserializeFromBase64(type, base64);
    }
}