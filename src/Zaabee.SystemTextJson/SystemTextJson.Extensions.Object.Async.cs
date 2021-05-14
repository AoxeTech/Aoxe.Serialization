using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zaabee.SystemTextJson
{
    public static partial class SystemTextJsonExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<T>(this T t, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(t, options);

        public static Task<MemoryStream> ToStreamAsync(this object obj, Type type, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(type, obj, options);

        public static Task PackToAsync<T>(this T t, Stream stream, JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(t, stream, options);

        public static Task PackToAsync(this object obj, Type type, Stream stream,
            JsonSerializerOptions options = null) =>
            SystemTextJsonHelper.PackAsync(type, obj, stream, options);
    }
}