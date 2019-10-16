using System;
using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackHelper
    {
        public static async Task<byte[]> SerializeAsync<T>(T t)
        {
            if (t == null) return new byte[0];
            using var stream = await PackAsync(t);
            return await StreamToBytesAsync(stream);
        }

        public static async Task<Stream> PackAsync<T>(T t)
        {
            var ms = new MemoryStream();
            if (t == null) return ms;
            await PackAsync(t, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            if (t == null) return;
            var serializer = MessagePackSerializer.Get<T>();
            await serializer.PackAsync(stream, t);
        }

        public static async Task<byte[]> SerializeAsync(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using var stream = await PackAsync(type, obj);
            return await StreamToBytesAsync(stream);
        }

        public static async Task<Stream> PackAsync(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            await PackAsync(type, obj, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync(Type type, object obj, Stream stream)
        {
            if (obj is null) return;
            var serializer = MessagePackSerializer.Get(type);
            await Task.Run(() => serializer.Pack(stream, obj));
        }

        public static async Task<T> DeserializeAsync<T>(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default;
            using var ms = new MemoryStream(bytes);
            return await UnpackAsync<T>(ms);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            if (stream is null) return default;
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return await serializer.UnpackAsync(stream);
        }

        public static async Task<object> DeserializeAsync(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return await UnpackAsync(type, ms);
        }

        public static async Task<object> UnpackAsync(Type type, Stream stream)
        {
            if (stream is null) return default(Type);
            var serializer = MessagePackSerializer.Get(type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return await Task.Run(() => serializer.Unpack(stream));
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