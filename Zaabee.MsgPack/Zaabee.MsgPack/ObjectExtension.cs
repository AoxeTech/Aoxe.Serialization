using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Serialize the object to bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToMsgPack<T>(this T obj) =>
            MsgPackHelper.Serialize(obj);

        public static byte[] ToMsgPack(this object obj, Type type) =>
            MsgPackHelper.Serialize(obj, type);

        /// <summary>
        /// Serialize the object to stream
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static void ToMsgPack<T>(this T obj, Stream stream) =>
            MsgPackHelper.Pack(stream, obj);

        public static void ToMsgPack(this object obj, Type type, Stream stream) =>
            MsgPackHelper.Pack(stream, obj, type);
    }
}