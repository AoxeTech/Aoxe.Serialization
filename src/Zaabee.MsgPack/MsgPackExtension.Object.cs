using System;
using System.IO;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackExtension
    {
        public static string ToBase64<T>(this T t) => MsgPackHelper.SerializeToBase64(t);

        public static string ToBase64(this object obj, Type type) => MsgPackHelper.SerializeToBase64(type, obj);

        public static byte[] ToBytes<T>(this T t) => MsgPackHelper.Serialize(t);

        public static MemoryStream ToStream<T>(this T t) => MsgPackHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) => MsgPackHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) => MsgPackHelper.Serialize(type, obj);

        public static MemoryStream ToStream(this object obj, Type type) => MsgPackHelper.Pack(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) => MsgPackHelper.Pack(type, obj, stream);
    }
}