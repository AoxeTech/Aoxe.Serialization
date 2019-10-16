using System;
using System.IO;
using System.Threading.Tasks;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufHelper
    {
        public static async Task<byte[]> SerializeAsync(object obj)
        {
            if (obj is null) return new byte[0];
            using var stream = await PackAsync(obj);
            return await StreamToBytesAsync(stream);
        }

        public static async Task<Stream> PackAsync(object obj)
        {
            var ms = new MemoryStream();
            if (obj != null) await PackAsync(obj, ms);
            return ms;
        }

        public static async Task PackAsync(object obj, Stream stream)
        {
            if (obj != null) await Task.Run(() => Model.Serialize(stream, obj));
        }

        public static async Task<T> DeserializeAsync<T>(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default;
            return (T) await DeserializeAsync(typeof(T), bytes);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            if (stream is null || stream.Length == 0) return default;
            return (T) await UnpackAsync(typeof(T), stream);
        }

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return await UnpackAsync(type, ms);
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream)
        {
            if (stream is null || stream.Length == 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return await Task.Run(() => Model.Deserialize(stream, null, type));
        }

        private static async Task<byte[]> StreamToBytesAsync(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            await stream.ReadAsync(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}