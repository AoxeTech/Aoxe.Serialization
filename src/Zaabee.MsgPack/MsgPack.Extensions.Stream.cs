using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtensions
    {
        public static void PackBy<T>(this Stream stream, T obj) =>
            MsgPackHelper.Pack(obj, stream);

        public static void PackBy(this Stream stream, Type type, object obj) =>
            MsgPackHelper.Pack(type, obj, stream);

        public static T Unpack<T>(this Stream stream) =>
            MsgPackHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream, Type type) =>
            MsgPackHelper.Unpack(type, stream);
    }
}