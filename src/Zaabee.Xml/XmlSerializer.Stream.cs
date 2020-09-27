using System;
using System.Collections.Concurrent;
using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Xml
{
    public static partial class XmlSerializer
    {
        private static readonly ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer> SerializerCache =
            new ConcurrentDictionary<Type, System.Xml.Serialization.XmlSerializer>();

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using a memory stream.
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemoryStream Pack<T>(T t) =>
            Pack(typeof(T), t);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using a memory stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static MemoryStream Pack(Type type, object obj)
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
        public static void Pack<T>(T t, Stream stream) =>
            Pack(typeof(T), t, stream);

        /// <summary>
        /// Serializes the specified object and writes the XML document to a file using the specified stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(Type type, object obj, Stream stream)
        {
            GetSerializer(type).Serialize(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Deserializes the XML document contained by the specified stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream) =>
            (T) Unpack(typeof(T), stream);

        /// <summary>
        /// Deserializes the XML document contained by the specified stream.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object Unpack(Type type, Stream stream)
        {
            var result = GetSerializer(type).Deserialize(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        private static System.Xml.Serialization.XmlSerializer GetSerializer(Type type) =>
            SerializerCache.GetOrAdd(type, new System.Xml.Serialization.XmlSerializer(type));
    }
}