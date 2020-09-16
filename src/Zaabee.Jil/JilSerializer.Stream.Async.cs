using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jil;
using Zaabee.Extensions;

namespace Zaabee.Jil
{
    public static partial class JilSerializer
    {
        public static async Task<MemoryStream> PackAsync<T>(T t, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms, options, encoding);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream, Options options, Encoding encoding)
        {
            await Serialize(t, options, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<MemoryStream> PackAsync(object obj, Options options, Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(obj, ms, options, encoding);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, Options options, Encoding encoding)
        {
            await Serialize(obj, options, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize<T>(encoding.GetString(await stream.ReadToEndAsync()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options, Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), options);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}