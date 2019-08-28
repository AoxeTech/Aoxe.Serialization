using System.IO;

namespace Zaabee.Binary
{
    public static class ObjectExtension
    {
        public static byte[] ToBinary(this object obj) =>
            BinaryHelper.Serialize(obj);

        public static Stream PackBinary(this object obj) =>
            BinaryHelper.Pack(obj);

        public static void PackBinary(this object obj, Stream stream) =>
            BinaryHelper.Pack(obj, stream);
    }
}