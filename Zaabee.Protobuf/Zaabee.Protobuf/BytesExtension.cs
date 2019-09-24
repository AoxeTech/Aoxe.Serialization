using System;
using System.Threading.Tasks;

namespace Zaabee.Protobuf
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            ProtobufHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            ProtobufHelper.Deserialize(type, bytes);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes) =>
            await ProtobufHelper.DeserializeAsync<T>(bytes);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type) =>
            await ProtobufHelper.DeserializeAsync(type, bytes);
    }
}