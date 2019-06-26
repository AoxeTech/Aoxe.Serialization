using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zaabee.Binary
{
    public static class BinaryHelper
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        /// <summary>
        /// Serialize the object to byte[]
        /// </summary>
        /// <param name="o">obj
        /// ect</param>
        /// <returns>json</returns>
        public static byte[] Serialize<T>(T o)
        {
            if (_binaryFormatter == null) _binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, o);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deserialize the byte[] to the generic object(if the byte[] is null the length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="bytes">json</param>
        /// <returns>generic object</returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            if (_binaryFormatter == null) _binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream(bytes))
                return (T) _binaryFormatter.Deserialize(ms);
        }
    }
}