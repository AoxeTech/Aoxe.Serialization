using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class SystemTextJsonExtension
    {

        public static Task PackByAsync<T>(this Stream stream, T obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(obj, stream, resolver);

        public static Task PackByAsync(this Stream stream, Type type, object obj,
            IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(type, obj, stream, resolver);

        public static Task<T> UnpackAsync<T>(this Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.UnpackAsync<T>(stream, resolver);

        public static Task<object> UnpackAsync(this Stream stream, Type type,
            IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.UnpackAsync(type, stream, resolver);
    }
}