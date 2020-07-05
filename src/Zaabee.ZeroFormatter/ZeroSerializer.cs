using System;
using System.IO;
using Zaabee.Extensions;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroSerializer
    {
        #region Bytes

        public static byte[] Serialize<T>(T t) =>
            t is null ? new byte[0] : ZeroFormatterSerializer.Serialize(t);

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? default : ZeroFormatterSerializer.Deserialize<T>(bytes);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes.IsNullOrEmpty() ? default(Type) : ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            if (t is null) return ms;
            Pack(t, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null) return;
            ZeroFormatterSerializer.Serialize(stream, t);
        }

        public static T Unpack<T>(Stream stream) =>
            stream is null ? default : ZeroFormatterSerializer.Deserialize<T>(stream);

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj is null) return;
            ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
        }

        public static object Unpack(Type type, Stream stream) =>
            stream is null ? default(Type) : ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);

        #endregion
    }
}