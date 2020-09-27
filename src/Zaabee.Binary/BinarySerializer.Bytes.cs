using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security;

namespace Zaabee.Binary
{
    public static partial class BinarySerializer
    {
        /// <summary>
        /// Pack the object into a memory stream and return a bytes contains the stream contents.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The obj is null.</exception>
        /// <exception cref="SerializationException">An error has occurred during serialization, such as if the object is not marked as serializable.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static byte[] Serialize(object obj) => Pack(obj).ToArray();

        /// <summary>
        /// Initializes a new memory stream based on the bytes and unpack it.
        /// </summary>
        /// <param name="bytes"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="SerializationException">An error occurred while deserializing an object from the stream.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(bytes);

        /// <summary>
        /// Initializes a new memory stream based on the bytes and unpack it.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException">An error occurred while deserializing an object from the stream.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="NotSupportedException">ASP.NET 5.0 and later: Always thrown unless BinaryFormatter functionality is re-enabled in the project file. For more information, see Resolving BinaryFormatter obsoletion and disablement errors.</exception>
        public static object Deserialize(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }
    }
}