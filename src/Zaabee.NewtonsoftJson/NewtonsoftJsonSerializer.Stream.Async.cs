using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zaabee.Extensions;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonSerializer
    {
        public static async Task<MemoryStream> PackAsync(object obj, JsonSerializerSettings settings, Encoding encoding)
        {
            var ms = new MemoryStream();
            await PackAsync(obj, ms, settings, encoding);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            await Serialize(obj, settings, encoding).WriteToAsync(stream, CancellationToken.None);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings, Encoding encoding) =>
            (T) await UnpackAsync(typeof(T), stream, settings, encoding);

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings,
            Encoding encoding)
        {
            var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), settings);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}