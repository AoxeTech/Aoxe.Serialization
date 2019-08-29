using System;
using System.IO;
using MsgPack.Serialization;

namespace Zaabee.MsgPack
{
    public static class MsgPackHelper
    {
        public static byte[] Serialize<T>(T t)
        {
            if (t == null) return new byte[0];
            using (var ms = (MemoryStream) Pack(t))
                return ms.ToArray();
        }

        public static Stream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            if (t == null) return ms;
            Pack(t, ms);
            return ms;
        }

        public static void Pack<T>(T t, Stream stream)
        {
            if (t == null) return;
            var serializer = MessagePackSerializer.Get<T>();
            serializer.Pack(stream, t);
        }

        public static byte[] Serialize(Type type, object obj)
        {
            if (obj == null) return new byte[0];
            using (var ms = (MemoryStream) Pack(type, obj))
                return ms.ToArray();
        }

        public static Stream Pack(Type type, object obj)
        {
            var ms = new MemoryStream();
            if (obj is null) return ms;
            Pack(type, obj, ms);
            return ms;
        }

        public static void Pack(Type type, object obj, Stream stream)
        {
            if (obj == null) return;
            var serializer = MessagePackSerializer.Get(type);
            serializer.Pack(stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            using (var ms = new MemoryStream(bytes))
                return Unpack<T>(ms);
        }

        public static T Unpack<T>(Stream stream)
        {
            if (stream == null) return default(T);
            var serializer = MessagePackSerializer.Get<T>();
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return serializer.Unpack(stream);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(Type);
            using (var ms = new MemoryStream(bytes))
                return Unpack(type, ms);
        }

        public static object Unpack(Type type, Stream stream)
        {
            if (stream == null) return default(Type);
            var serializer = MessagePackSerializer.Get(type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return serializer.Unpack(stream);
        }
    }
}