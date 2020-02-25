using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes<T>(this T t) => MsgPackHelper.Serialize(t);

        public static Stream ToStream<T>(this T t) => MsgPackHelper.Pack(t);

        public static void PackTo<T>(this T t, Stream stream) => MsgPackHelper.Pack(t, stream);

        public static byte[] ToBytes(this object obj, Type type) => MsgPackHelper.Serialize(type, obj);

        public static Stream ToStream(this object obj, Type type) => MsgPackHelper.Pack(type, obj);

        public static void PackTo(this object obj, Type type, Stream stream) => MsgPackHelper.Pack(type, obj, stream);

        public static async Task PackToAsync<T>(this T t, Stream stream) => await MsgPackHelper.PackAsync(t, stream);
    }
}