using System;
using System.IO;
using ZeroFormatter;

namespace Zaabee.ZeroFormatter
{
    public static class ZeroFormatterHelper
    {
        /// <summary>
        /// Serialize the object to byte[](if the generic object == null then return new byte[0])
        /// </summary>
        /// <param name="t">generic object</param>
        /// <returns>bytes</returns>
        public static byte[] Serialize<T>(T t) =>
            t == null ? new byte[0] : ZeroFormatterSerializer.Serialize(t);

        public static Stream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            if (t == null) return ms;
            ZeroFormatterSerializer.Serialize(ms, t);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            if (t != null) ZeroFormatterSerializer.Serialize(stream, t);
        }

        public static byte[] Serialize(Type type, object obj) =>
            obj is null ? new byte[0] : ZeroFormatterSerializer.NonGeneric.Serialize(type, obj);

        public static Stream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            ZeroFormatterSerializer.NonGeneric.Serialize(type, ms, obj);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj != null) ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
        }

        /// <summary>
        /// Deserialize the byte[] to the generic object(if the bytes is null or its length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T">generic</typeparam>
        /// <param name="bytes">bytes</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes) =>
            bytes is null || bytes.Length == 0 ? default(T) : ZeroFormatterSerializer.Deserialize<T>(bytes);

        public static T UnPack<T>(Stream stream) =>
            stream is null ? default(T) : ZeroFormatterSerializer.Deserialize<T>(stream);

        public static object Deserialize(Type type, byte[] bytes) =>
            bytes is null || bytes.Length == 0 ? null : ZeroFormatterSerializer.NonGeneric.Deserialize(type, bytes);

        public static object UnPack(Type type, Stream stream) =>
            stream is null ? null : ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
    }
}