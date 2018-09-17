using System;
using System.IO;
using ProtoBuf;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        /// <summary>
        /// Serialize the object by protobuf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t)
        {
            SerializerBuilder.Build<T>();
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, t);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or white space then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null) return default(T);
            SerializerBuilder.Build<T>();
            using (var ms = new MemoryStream(bytes))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or white space then return null)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes, Type type)
        {
            if (bytes == null) return null;
            SerializerBuilder.Build(type);
            using (var ms = new MemoryStream(bytes))
            {
                return Serializer.Deserialize(type, ms);
            }
        }
    }
}