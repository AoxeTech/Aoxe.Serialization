using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static class StreamExtension
    {
        public static void PackMsgPack<T>(this Stream stream, T obj) =>
            MsgPackHelper.Pack(obj, stream);

        public static void PackMsgPack(this Stream stream, Type type, object obj) =>
            MsgPackHelper.Pack(type, obj, stream);

        public static T UnpackMsgPack<T>(this Stream stream) =>
            MsgPackHelper.Unpack<T>(stream);

        public static object UnpackMsgPack(this Stream stream, Type type) =>
            MsgPackHelper.Unpack(type, stream);
    }
}