using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonExtensions
    {
        public static T FromBytes<T>(this ReadOnlySpan<byte> bytes, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize<T>(bytes, options);

        public static object FromBytes(this ReadOnlySpan<byte> bytes, Type type,
            JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize(type, bytes, options);
    }
}