using System;
using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackSerializer
    {
        #region Bytes

        public static byte[] Serialize<T>(T t)
        {
            using var ms = Pack(t);
            return ms.ToArray();
        }

        public static byte[] Serialize(Type type, object obj)
        {
            using var ms = Pack(type, obj);
            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack<T>(ms);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }

        #endregion

        #region Stream

        public static MemoryStream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            Pack(t, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            var serializer = MessagePackSerializer.Get<T>();
            serializer.Pack(stream, t);
        }

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            var serializer = MessagePackSerializer.Get(type);
            serializer.Pack(stream, obj);
        }

        public static T Unpack<T>(Stream stream)
        {
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0) stream.Position = 0;
            return serializer.Unpack(stream);
        }

        public static object Unpack(Type type, Stream stream)
        {
            var serializer = MessagePackSerializer.Get(type);
            if (stream.CanSeek && stream.Position > 0) stream.Position = 0;
            return serializer.Unpack(stream);
        }

        #endregion

        #region StreamAsync

        public static async Task<MemoryStream> PackAsync<T>(T t)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            var serializer = MessagePackSerializer.Get<T>();
            await serializer.PackAsync(stream, t);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0) stream.Seek(0, SeekOrigin.Begin);
            return await serializer.UnpackAsync(stream);
        }

        #endregion
    }
}