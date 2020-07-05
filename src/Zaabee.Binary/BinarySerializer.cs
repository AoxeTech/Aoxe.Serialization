using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zaabee.Binary
{
    public static class BinarySerializer
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

        #region Bytes

        public static byte[] Serialize(object obj) => Pack(obj).ToArray();

        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(bytes);

        public static object Deserialize(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }

        #endregion

        #region Stream

        public static MemoryStream Pack(object obj)
        {
            var ms = new MemoryStream();
            Pack(obj, ms);
            return ms;
        }

        public static void Pack(object obj, Stream stream)
        {
            _binaryFormatter ??= new BinaryFormatter();
            _binaryFormatter.Serialize(stream, obj);
        }

        public static T Unpack<T>(Stream stream) => (T) Unpack(stream);

        public static object Unpack(Stream stream)
        {
            if (stream.CanSeek && stream.Position > 0) stream.Position = 0;
            _binaryFormatter ??= new BinaryFormatter();
            return _binaryFormatter.Deserialize(stream);
        }

        #endregion
    }
}