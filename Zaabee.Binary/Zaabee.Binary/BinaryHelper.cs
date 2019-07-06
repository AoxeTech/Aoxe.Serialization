using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zaabee.Binary
{
    public static class BinaryHelper
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        /// <summary>
        /// Serialize the object to byte[](if the generic object == null then return new byte[0])
        /// </summary>
        /// <param name="t">generic object</param>
        /// <returns>bytes</returns>
        public static byte[] Serialize<T>(T t)
        {
            if (t == null) return new byte[0];
            if (_binaryFormatter == null) _binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, t);
                return ms.ToArray();
            }
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
            if (_binaryFormatter == null) _binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream(bytes))
                return (T) _binaryFormatter.Deserialize(ms);
        }
    }
}