using System.IO;
using Zaabee.Extensions;

namespace Zaabee.Binary
{
    public static class BinaryHelper
    {
        #region Bytes
        
        public static byte[] Serialize(object obj) =>
            obj is null ? new byte[0] : BinarySerializer.Serialize(obj);

        public static T Deserialize<T>(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? default : BinarySerializer.Deserialize<T>(bytes);

        public static object Deserialize(byte[] bytes) =>
            bytes.IsNullOrEmpty() ? null : BinarySerializer.Deserialize(bytes);

        #endregion

        #region Stream

        public static MemoryStream Pack(object obj) =>
            obj is null ? new MemoryStream() : BinarySerializer.Pack(obj);

        public static void Pack(object obj, Stream stream)
        {
            if (obj is null || stream is null) return;
            BinarySerializer.Pack(obj, stream);
        }

        public static T Unpack<T>(Stream stream) =>
            stream is null ? default : BinarySerializer.Unpack<T>(stream);

        public static object Unpack(Stream stream) =>
            stream is null ? null : BinarySerializer.Unpack(stream);

        #endregion
    }
}