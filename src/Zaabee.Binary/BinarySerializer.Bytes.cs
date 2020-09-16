using System.IO;

namespace Zaabee.Binary
{
    public static partial class BinarySerializer
    {
        public static byte[] Serialize(object obj) => Pack(obj).ToArray();

        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(bytes);

        public static object Deserialize(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(ms);
        }
    }
}