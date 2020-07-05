using System.IO;

namespace Zaabee.Protobuf
{
    public static class ObjectExtension
    {
        public static byte[] ToBytes(this object obj) => ProtobufHelper.Serialize(obj);

        public static MemoryStream ToStream(this object obj) => ProtobufHelper.Pack(obj);

        public static void PackTo(this object obj, Stream stream) => ProtobufHelper.Pack(obj, stream);
    }
}