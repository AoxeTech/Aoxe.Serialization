using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonExtensions
    {
        public static Task<MemoryStream> ToStreamAsync<T>(this T t, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(t, settings, encoding);

        public static Task<MemoryStream> ToStreamAsync(this object obj, Type type,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, obj, settings, encoding);

        public static Task PackToAsync<T>(this T t, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(t, stream, settings, encoding);

        public static Task PackToAsync(this object obj, Type type, Stream stream,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            NewtonsoftJsonHelper.PackAsync(type, obj, stream, settings, encoding);
    }
}