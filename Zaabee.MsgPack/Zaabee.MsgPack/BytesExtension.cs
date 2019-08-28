using System;

namespace Zaabee.MsgPack
{
    public static class BytesExtension
    {
        public static T FromMsgPak<T>(this byte[] bytes) =>
            MsgPackHelper.Deserialize<T>(bytes);

        public static object FromMsgPak(this byte[] bytes, Type type) =>
            MsgPackHelper.Deserialize(type, bytes);
    }
}