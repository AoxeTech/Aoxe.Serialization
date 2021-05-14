using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static Task PackByAsync<T>(this Stream stream, T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(t, stream, settings, encoding);

        public static Task PackByAsync(this Stream stream, Type type, object obj,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, obj, stream, settings, encoding);

        public static Task<T> UnpackAsync<T>(this Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.UnpackAsync<T>(stream, settings, encoding);

        public static Task<object> UnpackAsync(this Stream stream, Type type,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.UnpackAsync(type, stream, settings, encoding);
    }
}