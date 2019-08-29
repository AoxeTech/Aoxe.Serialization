using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static class StreamExtension
    {
        public static void Pack<T>(this Stream stream, T obj) =>
            MsgPackHelper.Pack(obj, stream);

        public static void Pack(this Stream stream, Type type, object obj) =>
            MsgPackHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            MsgPackHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            MsgPackHelper.Unpack(type, stream);
    }
}