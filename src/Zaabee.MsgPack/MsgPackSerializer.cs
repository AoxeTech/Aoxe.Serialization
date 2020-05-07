using System;
using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackSerializer
    {
        #region Sync

        public static byte[] Serialize<T>(T t)
        {
            if (t is null) return new byte[0];
            using var stream = Pack(t);
            return ReadToEnd(stream);
        }

        public static Stream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            if (t is null) return ms;
            Pack(t, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            if (t is null) return;
            var serializer = MessagePackSerializer.Get<T>();
            serializer.Pack(stream, t);
        }

        public static byte[] Serialize(Type type, object obj)
        {
            if (obj is null) return new byte[0];
            using var stream = Pack(type, obj);
            return ReadToEnd(stream);
        }

        public static Stream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(type, obj, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj is null) return;
            var serializer = MessagePackSerializer.Get(type);
            serializer.Pack(stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default;
            using var ms = new MemoryStream(bytes);
            return Unpack<T>(ms);
        }

        public static T Unpack<T>(Stream stream)
        {
            if (stream is null) return default;
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return serializer.Unpack(stream);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length == 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }

        public static object Unpack(Type type, Stream stream)
        {
            if (stream is null) return default(Type);
            var serializer = MessagePackSerializer.Get(type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return serializer.Unpack(stream);
        }

        #endregion

        #region Async

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            if (t is null) return;
            var serializer = MessagePackSerializer.Get<T>();
            await serializer.PackAsync(stream, t);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            if (stream is null) return default;
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            return await serializer.UnpackAsync(stream);
        }

        #endregion

        private static byte[] ReadToEnd(this Stream stream)
        {
            if (stream is MemoryStream ms) return ms.ToArray();
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}