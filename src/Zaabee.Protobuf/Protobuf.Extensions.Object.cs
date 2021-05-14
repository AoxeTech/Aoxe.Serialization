using System.IO;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufExtensions
    {
        public static string ToBase64<T>(this T t) => ProtobufHelper.SerializeToBase64(t);

        public static string ToBase64(this object obj) => ProtobufHelper.SerializeToBase64(obj);
        
        public static byte[] ToBytes<T>(this T t) => ProtobufHelper.Serialize(t);

        public static byte[] ToBytes(this object obj) => ProtobufHelper.Serialize(obj);

        public static MemoryStream ToStream<T>(this T t) => ProtobufHelper.Pack(t);

        public static MemoryStream ToStream(this object obj) => ProtobufHelper.Pack(obj);

        public static void PackTo<T>(this T t, Stream stream) => ProtobufHelper.Pack(t, stream);

        public static void PackTo(this object obj, Stream stream) => ProtobufHelper.Pack(obj, stream);
    }
}