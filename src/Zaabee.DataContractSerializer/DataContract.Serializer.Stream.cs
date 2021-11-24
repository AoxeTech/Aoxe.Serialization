using System;
using System.Collections.Concurrent;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.DataContractSerializer
{
    public static partial class DataContractSerializer
    {
        private static readonly ConcurrentDictionary<Type, System.Runtime.Serialization.DataContractSerializer>
            SerializerCache = new();

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using a memory stream.
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemoryStream Pack<T>(T? t) =>
            Pack(typeof(T), t);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using a memory stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static MemoryStream Pack(Type type, object? obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T? t, Stream stream) =>
            Pack(typeof(T), t, stream);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(Type type, object? obj, Stream stream)
        {
            GetSerializer(type).WriteObject(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Deserializes the XML document contained by the specified stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T? Unpack<T>(Stream stream) =>
            (T)Unpack(typeof(T), stream)!;

        /// <summary>
        /// Deserializes the XML document contained by the specified stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object? Unpack(Type type, Stream stream)
        {
            var result = GetSerializer(type).ReadObject(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        private static System.Runtime.Serialization.DataContractSerializer GetSerializer(Type type) =>
            SerializerCache.GetOrAdd(type, new System.Runtime.Serialization.DataContractSerializer(type));
    }
}