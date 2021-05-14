using System;
using Utf8Json;
using Zaabee.Extensions;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonHelper
    {
        public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(value, resolver ?? DefaultJsonFormatterResolver);

        public static ArraySegment<byte> SerializeUnsafe<T>(T value, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeUnsafe(value, resolver ?? DefaultJsonFormatterResolver);

        public static byte[] Serialize(object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(obj, resolver ?? DefaultJsonFormatterResolver);

        public static byte[] Serialize(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.Serialize(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static ArraySegment<byte>
            SerializeUnsafe(Type type, object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeUnsafe(type, obj, resolver ?? DefaultJsonFormatterResolver);

        public static ArraySegment<byte> SerializeUnsafe(object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonSerializer.SerializeUnsafe(obj, resolver ?? DefaultJsonFormatterResolver);

        public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : Utf8JsonSerializer.Deserialize<T>(bytes, resolver ?? DefaultJsonFormatterResolver);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : Utf8JsonSerializer.Deserialize(type, bytes, resolver ?? DefaultJsonFormatterResolver);
    }
}