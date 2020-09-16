using System;
using System.Text.Json;
using Zaabee.Extensions;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonHelper
    {
        public static byte[] Serialize<T>(T o, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.Serialize(o, options ?? DefaultJsonSerializerOptions);

        public static byte[] Serialize(Type type, object value, JsonSerializerOptions options = null) =>
            SystemTextJsonSerializer.Serialize(type, value, options ?? DefaultJsonSerializerOptions);

        public static T Deserialize<T>(byte[] bytes, JsonSerializerOptions options = null) =>
            bytes.IsNullOrEmpty()
                ? (T) typeof(T).GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize<T>(bytes, options ?? DefaultJsonSerializerOptions);

        public static object Deserialize(Type type, byte[] bytes, JsonSerializerOptions options = null) =>
            bytes.IsNullOrEmpty()
                ? type.GetDefaultValue()
                : SystemTextJsonSerializer.Deserialize(type, bytes, options ?? DefaultJsonSerializerOptions);
    }
}