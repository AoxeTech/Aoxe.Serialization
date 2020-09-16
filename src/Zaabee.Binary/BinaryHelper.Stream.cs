using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static partial class BinaryHelper
    {
        public static MemoryStream Pack(object obj) =>
            obj is null ? new MemoryStream() : BinarySerializer.Pack(obj);

        public static void Pack(object obj, Stream stream)
        {
            if (obj is null || stream is null) return;
            BinarySerializer.Pack(obj, stream);
        }

        public static T Unpack<T>(Stream stream) =>
            stream.IsNullOrEmpty() ? (T) typeof(T).GetDefaultValue() : BinarySerializer.Unpack<T>(stream);

        public static object Unpack(Stream stream) =>
            stream.IsNullOrEmpty() ? null : BinarySerializer.Unpack(stream);
    }
}