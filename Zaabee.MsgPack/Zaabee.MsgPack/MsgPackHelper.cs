using System;
using System.IO;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackHelper
    {
        /// <summary>
        /// Serialize the object to byte[](if the generic object == null then return new byte[0])
        /// </summary>
        /// <param name="t">generic object</param>
        /// <returns>bytes</returns>
        public static byte[] Serialize<T>(T t)
        {
            if (t == null) return new byte[0];
            var serializer = MessagePackSerializer.Get<T>();
            using (var ms = new MemoryStream())
            {
                serializer.Pack(ms, t);
                return ms.ToArray();
            }
        }

        public static void Pack<T>(Stream stream, T t)
        {
            if (t == null) return;
            var serializer = MessagePackSerializer.Get<T>();
            serializer.Pack(stream, t);
        }

        public static byte[] Serialize(object obj, Type type)
        {
            if (obj == null) return new byte[0];
            var serializer = MessagePackSerializer.Get(type);
            using (var ms = new MemoryStream())
            {
                serializer.Pack(ms, obj);
                return ms.ToArray();
            }
        }

        public static void Pack(Stream stream, object obj, Type type)
        {
            if (obj == null) return;
            var serializer = MessagePackSerializer.Get(type);
            serializer.Pack(stream, obj);
        }

        /// <summary>
        /// Deserialize the byte[] to the generic object(if the bytes is null or its length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T">generic</typeparam>
        /// <param name="bytes">bytes</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            var serializer = MessagePackSerializer.Get<T>();
            using (var ms = new MemoryStream(bytes))
                return serializer.Unpack(ms);
        }

        public static T UnPack<T>(Stream stream)
        {
            if (stream == null) return default(T);
            var serializer = MessagePackSerializer.Get<T>();
            return serializer.Unpack(stream);
        }

        public static object Deserialize(byte[] bytes, Type type)
        {
            if (bytes == null || bytes.Length == 0) return null;
            var serializer = MessagePackSerializer.Get(type);
            using (var ms = new MemoryStream(bytes))
                return serializer.Unpack(ms);
        }

        public static object UnPack(Stream stream, Type type)
        {
            if (stream == null) return null;
            var serializer = MessagePackSerializer.Get(type);
            return serializer.Unpack(stream);
        }
    }
}