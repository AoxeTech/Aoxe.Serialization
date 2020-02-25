using System;
using System.Text.Json;

namespace Zaabee.SystemTextJson
{
    public static class BytesExtension
    {
        public static T FromBytes<T>(this byte[] bytes, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize<T>(bytes, options);

        public static object FromBytes(this byte[] bytes, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.Deserialize(type, bytes, options);
    }
}