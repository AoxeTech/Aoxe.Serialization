using System.IO;

namespace Zaabee.Binary
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes(this object obj) =>
            BinaryHelper.Serialize(obj);

        public static Stream ToStream(this object obj) =>
            BinaryHelper.Pack(obj);

        public static void PackTo(this object obj, Stream stream) =>
            BinaryHelper.Pack(obj, stream);
    }
}