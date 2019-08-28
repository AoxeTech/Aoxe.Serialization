using System.IO;

namespace Zaabee.Protobuf
{
    public static class ObjectExtension
    {
        public static byte[] ToProtobuf(this object obj) =>
            ProtobufHelper.Serialize(obj);

        public static Stream PackProtobuf(this object obj) =>
            ProtobufHelper.Pack(obj);

        public static void PackProtobuf(this object obj, Stream stream) =>
            ProtobufHelper.Pack(obj, stream);
    }
}