using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonExtensions
    {
        public static Task PackByAsync<T>(this Stream stream, T obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(obj, stream, options);

        public static Task PackByAsync(this Stream stream, Type type, object obj, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(type, obj, stream, options);

        public static Task<T> UnpackAsync<T>(this Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.UnpackAsync<T>(stream, options);

        public static Task<object> UnpackAsync(this Stream stream, Type type,
            JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.UnpackAsync(type, stream, options);
    }
}