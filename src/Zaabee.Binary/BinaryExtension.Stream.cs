using System.IO;

namespace Zaabee.Binary
{
    public static partial class BinaryExtension
    {
        public static void PackBy<T>(this Stream stream, T obj) => BinaryHelper.Pack(obj, stream);

        public static T Unpack<T>(this Stream stream) => BinaryHelper.Unpack<T>(stream);

        public static object Unpack(this Stream stream) => BinaryHelper.Unpack(stream);
    }
}