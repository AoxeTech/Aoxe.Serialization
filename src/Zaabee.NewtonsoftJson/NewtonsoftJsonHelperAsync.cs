using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static partial class NewtonsoftJsonHelper
    {
        public static async Task PackAsync(object obj, Stream stream, JsonSerializerSettings settings = null)
        {
            if (obj is null) return;
            var bytes = Serialize(obj, settings);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, JsonSerializerSettings settings = null)
        {
            if (stream is null) return default;
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return Deserialize<T>(DefaultEncoding.GetString(bytes), settings);
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, JsonSerializerSettings settings = null)
        {
            if (stream is null) return default;
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return Deserialize(type, DefaultEncoding.GetString(bytes), settings);
        }
    }
}