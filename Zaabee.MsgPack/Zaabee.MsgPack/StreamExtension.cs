using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static class StreamExtension
    {
        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T FromMsgPak<T>(this Stream stream) =>
            MsgPackHelper.UnPack<T>(stream);

        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromMsgPak(this Stream stream, Type type) =>
            MsgPackHelper.UnPack(stream, type);

        public static void PackByMsgPack<T>(this Stream stream, T t) =>
            MsgPackHelper.Pack(stream, t);

        public static void PackByMsgPack(this Stream stream, object obj, Type type) =>
            MsgPackHelper.Pack(stream, obj, type);
    }
}