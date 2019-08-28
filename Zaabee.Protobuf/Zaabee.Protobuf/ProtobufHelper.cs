using System;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        private static readonly Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model => model.Value;

        public static byte[] Serialize(object obj)
        {
            if (obj is null) return new byte[0];
            using (var ms = (MemoryStream) Pack(obj))
            {
                Model.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static Stream Pack(object obj)
        {
            var stream = new MemoryStream();
            if (obj != null) Pack(obj, stream);
            return stream;
        }

        public static void Pack(object obj, Stream stream)
        {
            if (obj != null) Model.Serialize(stream, obj);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            return (T) Deserialize(typeof(T), bytes);
        }

        public static T UnPack<T>(Stream stream)
        {
            if (stream == null || stream.Length == 0) return default(T);
            var type = typeof(T);
            return (T) UnPack(type, stream);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            return UnPack(type, new MemoryStream(bytes));
        }

        public static object UnPack(Type type, Stream stream)
        {
            if (stream == null || stream.Length == 0) return null;
            if (stream.CanSeek)
                stream.Position = 0;
            return Model.Deserialize(stream, null, type);
        }

        public static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}