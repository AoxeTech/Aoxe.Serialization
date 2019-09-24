using System;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize<T>(bytes, resolver);

        public static object FromBytes(this byte[] bytes, Type type, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.Deserialize(type, bytes, resolver);

        public static async Task<T> FromBytesAsync<T>(this byte[] bytes, IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.DeserializeAsync<T>(bytes, resolver);

        public static async Task<object> FromBytesAsync(this byte[] bytes, Type type,
            IJsonFormatterResolver resolver = null) =>
            await Utf8JsonHelper.DeserializeAsync(type, bytes, resolver);
    }
}