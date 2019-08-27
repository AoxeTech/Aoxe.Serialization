using System;

namespace Zaabee.MsgPack
{
    public static class BytesExtension
    {
        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T FromMsgPak<T>(this byte[] bytes) =>
            MsgPackHelper.Deserialize<T>(bytes);

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromMsgPak(this byte[] bytes, Type type) =>
            MsgPackHelper.Deserialize(bytes, type);
    }
}