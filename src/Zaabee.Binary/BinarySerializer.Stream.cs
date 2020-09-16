using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static partial class BinarySerializer
    {
        [ThreadStatic] private static BinaryFormatter _binaryFormatter;

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
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream) => (T) Unpack(stream);

        public static object Unpack(Stream stream)
        {
            _binaryFormatter ??= new BinaryFormatter();
            var result = _binaryFormatter.Deserialize(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}