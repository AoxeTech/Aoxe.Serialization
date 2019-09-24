using System.IO;
using System.Threading.Tasks;

namespace Zaabee.Protobuf
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes(this object obj) =>
            ProtobufHelper.Serialize(obj);

        public static Stream ToStream(this object obj) =>
            ProtobufHelper.Pack(obj);

        public static void PackTo(this object obj, Stream stream) =>
            ProtobufHelper.Pack(obj, stream);

        public static async Task<byte[]> ToBytesAsync(this object obj) =>
            await ProtobufHelper.SerializeAsync(obj);

        public static async Task<Stream> ToStreamAsync(this object obj) =>
            await ProtobufHelper.PackAsync(obj);

        public static async Task PackToAsync(this object obj, Stream stream) =>
            await ProtobufHelper.PackAsync(obj, stream);
    }
}