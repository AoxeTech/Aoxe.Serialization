using System;
using System.IO;
using System.Threading.Tasks;
using Jil;

namespace Zaabee.Jil
{
    public static partial class JilHelper
    {
        public static async Task PackAsync<T>(T t, Stream stream, Options options = null)
        {
            if (t is null || !stream.CanWrite) await Task.CompletedTask;
            var bytes = Serialize(t, options);
            await stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream, Options options = null)
        {
            if (stream is null) return default;
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return JSON.Deserialize<T>(DefaultEncoding.GetString(bytes), options ?? DefaultOptions);
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream, Options options = null)
        {
            if (stream is null) return default;
            var bytes = new byte[stream.Length];
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return JSON.Deserialize(DefaultEncoding.GetString(bytes), type, options ?? DefaultOptions);
        }
    }
}