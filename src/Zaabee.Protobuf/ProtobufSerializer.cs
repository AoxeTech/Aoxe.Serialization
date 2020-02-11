using System;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufSerializer
    {
        private static readonly Lazy<RuntimeTypeModel> Model = new Lazy<RuntimeTypeModel>(() =>
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        });

        private static TypeModel TypeModel => Model.Value;

        public static byte[] Serialize(object obj)
        {
            if (obj is null) return new byte[0];
            using var stream = Pack(obj);
            return StreamToBytes(stream);
        }

        public static Stream Pack(object obj)
        {
            var ms = new MemoryStream();
            if (obj != null) Pack(obj, ms);
            return ms;
        }

        public static void Pack(object obj, Stream stream)
        {
            if (obj != null) TypeModel.Serialize(stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0) return default;
            return (T) Deserialize(typeof(T), bytes);
        }

        public static T Unpack<T>(Stream stream)
        {
            if (stream is null || stream.Length is 0) return default;
            var type = typeof(T);
            return (T) Unpack(type, stream);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes is null || bytes.Length is 0) return default(Type);
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }

        public static object Unpack(Type type, Stream stream)
        {
            if (stream is null || stream.Length is 0) return default(Type);
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return TypeModel.Deserialize(stream, null, type);
        }

        private static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            if (stream.Position > 0 && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}