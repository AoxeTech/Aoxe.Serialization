using System;
using System.IO;
using System.Threading.Tasks;
using MsgPack.Serialization;
using Zaabee.Extensions;

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
            return ms;
        }

        public static MemoryStream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            MessagePackSerializer.Get<T>().Pack(stream, t);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            MessagePackSerializer.Get(type).Pack(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream)
        {
            var result = MessagePackSerializer.Get<T>().Unpack(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        public static object Unpack(Type type, Stream stream)
        {
            var result = MessagePackSerializer.Get(type).Unpack(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        #endregion

        #region StreamAsync

        public static async Task<MemoryStream> PackAsync<T>(T t)
        {
            var ms = new MemoryStream();
            await PackAsync(t, ms);
            return ms;
        }

        public static async Task PackAsync<T>(T t, Stream stream)
        {
            await MessagePackSerializer.Get<T>().PackAsync(stream, t);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static async Task<T> UnpackAsync<T>(Stream stream)
        {
            var result = await MessagePackSerializer.Get<T>().UnpackAsync(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        #endregion
    }
}