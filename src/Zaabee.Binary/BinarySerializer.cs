using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zaabee.Binary
{
    public static class BinarySerializer
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        #region Bytes

        public static byte[] Serialize(object obj) => ReadToEnd(Pack(obj));

        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(bytes);

        public static object Deserialize(byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }

        #endregion

        #region Stream

        public static Stream Pack(object obj)
        {
            var ms = new MemoryStream();
            if (obj != null) Pack(obj, ms);
            return ms;
        }

        public static void Pack(object obj, Stream stream)
        {
            if (obj is null) return;
            _binaryFormatter ??= new BinaryFormatter();
            _binaryFormatter.Serialize(stream, obj);
        }

        public static T Unpack<T>(Stream stream) => (T) Unpack(stream);

        public static object Unpack(Stream stream)
        {
            if (stream is null || stream.Length is 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0) stream.Position = 0;
            _binaryFormatter ??= new BinaryFormatter();
            return _binaryFormatter.Deserialize(stream);
        }

        #endregion

        private static byte[] ReadToEnd(this Stream stream)
        {
            if (stream is MemoryStream ms) return ms.ToArray();
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}