using System;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace Zaabee.Utf8Json
{
    public static partial class Utf8JsonExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<T>(this T t, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(t, resolver);

        public static Task<MemoryStream> ToStreamAsync(this object obj, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(obj, resolver);

        public static Task<MemoryStream> ToStreamAsync(this object obj, Type type,
            IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(type, obj, resolver);

        public static Task PackToAsync<T>(this T t, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(t, stream, resolver);

        public static Task PackToAsync(this object obj, Stream stream, IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(obj, stream, resolver);

        public static Task PackToAsync(this object obj, Type type, Stream stream,
            IJsonFormatterResolver resolver = null) =>
            Utf8JsonHelper.PackAsync(type, obj, stream, resolver);
    }
}