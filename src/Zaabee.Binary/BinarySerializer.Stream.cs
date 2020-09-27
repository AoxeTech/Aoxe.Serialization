using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static partial class BinarySerializer
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        /// <summary>
        /// Serializes an object into a memory stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The obj is null.</exception>
        /// <exception cref="SerializationException">An error has occurred during serialization, such as if the object is not marked as serializable.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static MemoryStream Pack(object obj)
        {
            var ms = new MemoryStream();
            Pack(obj, ms);
            return ms;
        }

        /// <summary>
        /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentNullException">The obj is null or the stream is null.</exception>
        /// <exception cref="SerializationException">An error has occurred during serialization, such as if the object is not marked as serializable.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static void Pack(object obj, Stream stream)
        {
            _binaryFormatter ??= new BinaryFormatter();
            _binaryFormatter.Serialize(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Deserializes a stream into a generic object.
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The serializationStream is null.</exception>
        /// <exception cref="SerializationException">The serializationStream supports seeking, but its length is 0.</exception>
        /// <exception cref="SerializationException">The input stream does not represent a well-formed BinaryFormatter serialized payload.</exception>
        /// <exception cref="SerializationException">An error occurred while deserializing an object from the input stream.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static T Unpack<T>(Stream stream) => (T) Unpack(stream);

        /// <summary>
        /// Deserializes a stream into an object graph.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The serializationStream is null.</exception>
        /// <exception cref="SerializationException">The serializationStream supports seeking, but its length is 0.</exception>
        /// <exception cref="SerializationException">The input stream does not represent a well-formed BinaryFormatter serialized payload.</exception>
        /// <exception cref="SerializationException">An error occurred while deserializing an object from the input stream.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static object Unpack(Stream stream)
        {
            _binaryFormatter ??= new BinaryFormatter();
            var result = _binaryFormatter.Deserialize(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}