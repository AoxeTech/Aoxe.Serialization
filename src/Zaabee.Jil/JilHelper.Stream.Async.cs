using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static async Task<MemoryStream> PackAsync<T>(T t, Options options = null, Encoding encoding = null)
        {
            if (t is null) return new MemoryStream();
            return await JilSerializer.PackAsync(t, options, encoding ?? DefaultEncoding);
        }

        public static async Task<MemoryStream> PackAsync(object obj, Options options = null, Encoding encoding = null)
        {
            if (obj is null) return new MemoryStream();
            return await JilSerializer.PackAsync(obj, options, encoding ?? DefaultEncoding);
        }

        public static async Task PackAsync<T>(T t, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (t is null || stream is null) return;
            await JilSerializer.PackAsync(t, stream, options, encoding ?? DefaultEncoding);
        }

        public static async Task PackAsync(object obj, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (obj is null || stream is null) return;
            await JilSerializer.PackAsync(obj, stream, options, encoding ?? DefaultEncoding);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options = null, Encoding encoding = null) =>
            stream is null
                ? (T) typeof(T).GetDefaultValue()
                : await JilSerializer.UnpackAsync<T>(stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options = null,
            Encoding encoding = null) =>
            stream is null
                ? null
                : await JilSerializer.UnpackAsync(type, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
    }
}