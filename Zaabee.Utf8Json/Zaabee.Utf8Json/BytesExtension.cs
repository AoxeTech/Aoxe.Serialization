using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes) =>
            Utf8JsonHelper.Deserialize<T>(bytes);

        public static object FromBytes(this byte[] bytes, Type type) =>
            Utf8JsonHelper.Deserialize(type, bytes);

        public static object FromBytes(this byte[] bytes, Type type, IJsonFormatterResolver resolver) =>
            Utf8JsonHelper.Deserialize(type, bytes, resolver);
    }
}