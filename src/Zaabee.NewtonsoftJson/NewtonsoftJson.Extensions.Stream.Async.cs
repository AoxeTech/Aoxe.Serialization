using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static Task PackByAsync<TValue>(this Stream? stream, TValue value, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding);

        public static Task PackByAsync(this Stream? stream, Type type, object? value,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding);

        public static Task<TValue> UnpackAsync<TValue>(this Stream? stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.UnpackAsync<TValue>(stream, settings, encoding);

        public static Task<object> UnpackAsync(this Stream? stream, Type type,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.UnpackAsync(type, stream, settings, encoding);
    }
}