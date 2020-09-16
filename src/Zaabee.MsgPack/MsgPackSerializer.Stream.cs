using System;
using System.IO;
using MsgPack.Serialization;
using Zaabee.Extensions;

namespace Zaabee.MsgPack
{
    public static partial class MsgPackSerializer
    {
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
    }
}