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
        public static Task<MemoryStream> PackAsync<T>(T t, Options options = null, Encoding encoding = null) =>
            t is null
                ? Task.FromResult(new MemoryStream())
                : JilSerializer.PackAsync(t, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static Task<MemoryStream> PackAsync(object obj, Options options = null, Encoding encoding = null) =>
            obj is null
                ? Task.FromResult(new MemoryStream())
                : JilSerializer.PackAsync(obj, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static Task PackAsync<T>(T t, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (t is null || stream is null) return Task.CompletedTask;
            return JilSerializer.PackAsync(t, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
        }

        public static Task PackAsync(object obj, Stream stream, Options options = null, Encoding encoding = null)
        {
            if (obj is null || stream is null) return Task.CompletedTask;
            return JilSerializer.PackAsync(obj, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
        }

        public static Task<T> UnpackAsync<T>(Stream stream, Options options = null, Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult((T) typeof(T).GetDefaultValue())
                : JilSerializer.UnpackAsync<T>(stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);

        public static Task<object> UnpackAsync(Type type, Stream stream, Options options = null,
            Encoding encoding = null) =>
            stream.IsNullOrEmpty()
                ? Task.FromResult(type.GetDefaultValue())
                : JilSerializer.UnpackAsync(type, stream, options ?? DefaultOptions, encoding ?? DefaultEncoding);
    }
}