using System;
using System.Threading.Tasks;

namespace Zaabee.MsgPack
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            MsgPackHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            MsgPackHelper.Deserialize(type, bytes);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes) =>
            await MsgPackHelper.DeserializeAsync<T>(bytes);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type) =>
            await MsgPackHelper.DeserializeAsync(type, bytes);
    }
}