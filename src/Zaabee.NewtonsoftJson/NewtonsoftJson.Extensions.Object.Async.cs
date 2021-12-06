using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(value, settings, encoding);

        public static Task<MemoryStream> ToStreamAsync(this object? value, Type type,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, value, settings, encoding);

        public static Task PackToAsync<TValue>(this TValue value, Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding);

        public static Task PackToAsync(this object? value, Type type, Stream? stream,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding);
    }
}