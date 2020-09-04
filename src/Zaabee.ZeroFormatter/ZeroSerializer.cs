using System;
using System.IO;
using Zaabee.Extensions;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroSerializer
    {
        #region Bytes

        public static byte[] Serialize<T>(T t) => ZeroFormatterSerializer.Serialize(t);

        public static byte[] Serialize(Type type, object obj) =>
            ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        public static T Deserialize<T>(byte[] bytes) => ZeroFormatterSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            Pack(t, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream) => ZeroFormatterSerializer.Serialize(stream, t);

        public static T Unpack<T>(Stream stream) => ZeroFormatterSerializer.Deserialize<T>(stream);

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream) =>
            ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);

        public static object Unpack(Type type, Stream stream) =>
            ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);

        #endregion
    }
}