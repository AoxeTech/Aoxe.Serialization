using System.IO;

namespace Zaabee.Binary
{
    public static class BinaryHelper
    {
        public static byte[] Serialize(object obj) => BinarySerializer.Serialize(obj);

        public static Stream Pack(object obj) => BinarySerializer.Pack(obj);

        public static void Pack(object obj, Stream stream) => BinarySerializer.Pack(obj, stream);

        public static T Deserialize<T>(byte[] bytes) => (T) BinarySerializer.Deserialize(bytes);

        public static T Unpack<T>(Stream stream) => (T) BinarySerializer.Unpack(stream);

        public static object Deserialize(byte[] bytes) => BinarySerializer.Deserialize(bytes);

        public static object Unpack(Stream stream) => BinarySerializer.Unpack(stream);
    }
}