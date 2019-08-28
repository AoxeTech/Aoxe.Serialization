using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static class ObjectExtension
    {
        public static byte[] ToMsgPack<T>(this T t) =>
            MsgPackHelper.Serialize(t);

        public static Stream PackMsgPack<T>(this T t) =>
            MsgPackHelper.Pack(t);

        public static void PackMsgPack<T>(this T t, Stream stream) =>
            MsgPackHelper.Pack(t, stream);

        public static byte[] ToMsgPack(this object obj, Type type) =>
            MsgPackHelper.Serialize(type, obj);

        public static Stream PackMsgPack(this object obj, Type type) =>
            MsgPackHelper.Pack(type, obj);

        public static void PackMsgPack(this object obj, Type type, Stream stream) =>
            MsgPackHelper.Pack(type, obj, stream);
    }
}