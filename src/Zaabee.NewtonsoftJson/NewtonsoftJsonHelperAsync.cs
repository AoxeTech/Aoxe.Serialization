using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static async Task<MemoryStream> PackAsync(object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (obj is null) return new MemoryStream();
            return await NewtonsoftJsonSerializer.PackAsync(obj, settings ?? DefaultSettings,
                encoding ?? DefaultEncoding);
        }

        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null)
        {
            if (obj is null || stream is null) return;
            await NewtonsoftJsonSerializer.PackAsync(obj, stream, settings ?? DefaultSettings,
                encoding ?? DefaultEncoding);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : await NewtonsoftJsonSerializer.UnpackAsync<T>(stream, settings ?? DefaultSettings, DefaultEncoding);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings = null) =>
            stream is null
                ? type.GetDefaultValue()
                : await NewtonsoftJsonSerializer.UnpackAsync(type, stream, settings ?? DefaultSettings,
                    DefaultEncoding);
    }
}