using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize<T>(bytes, options);

        public static object FromBytes(this byte[] bytes, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize(type, bytes, options);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes, JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.DeserializeAsync<T>(bytes, options);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type,
            JsonSerializerOptions options = null) =>
            await SystemTextJsonHelper.DeserializeAsync(type, bytes, options);
    }
}