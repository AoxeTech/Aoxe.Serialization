using System;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonSerializer
    {
        public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver) =>
            JsonSerializer.Serialize(value, resolver);

        public static byte[] Serialize(Type type, object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(type, obj, resolver);

        public static byte[] Serialize(object obj, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Serialize(obj, resolver);

        public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver) =>
            JsonSerializer.Deserialize<T>(bytes, resolver);

        public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver) =>
            JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);
    }
}