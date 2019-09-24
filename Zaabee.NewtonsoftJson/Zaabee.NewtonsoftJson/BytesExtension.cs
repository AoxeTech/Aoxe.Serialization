using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize<T>(bytes, settings);

        public static object FromBytes(this byte[] bytes, Type type, JsonSerializerSettings settings = null) =>
            NewtonsoftJsonHelper.Deserialize(type, bytes, settings);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes, JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.DeserializeAsync<T>(bytes, settings);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type,
            JsonSerializerSettings settings = null) =>
            await NewtonsoftJsonHelper.DeserializeAsync(type, bytes, settings);
    }
}