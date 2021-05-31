using System.IO;

namespace Zaabee.Binary
{
    public static partial class BinaryExtensions
    {
        public static byte[] ToBytes(this object obj) => BinaryHelper.Serialize(obj);

        public static MemoryStream ToStream(this object obj) => BinaryHelper.Pack(obj);

        public static void PackTo(this object obj, Stream stream) => BinaryHelper.Pack(obj, stream);
    }
}