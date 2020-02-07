using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zaabee.Binary
{
    public static class BinarySerializer
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        public static byte[] Serialize(object obj)
        {
            using var stream = Pack(obj);
            return StreamToBytes(stream);
        }

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

        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(bytes);

        public static T Unpack<T>(Stream stream) => (T) Unpack(stream);

        public static object Deserialize(byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }

        public static object Unpack(Stream stream)
        {
            if (stream is null || stream.Length is 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            _binaryFormatter ??= new BinaryFormatter();
            return _binaryFormatter.Deserialize(stream);
        }

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}