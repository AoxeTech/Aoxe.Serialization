using System;
using System.Collections.Concurrent;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        private static readonly Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        private static RuntimeTypeModel Model => model.Value;

        private static readonly ConcurrentDictionary<Type, RuntimeTypeModel> Models =
            new ConcurrentDictionary<Type, RuntimeTypeModel>();

        /// <summary>
        /// Serialize the object by protobuf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T t)
        {
            SerializerBuilder.Build<T>(Model);
            return Serialize(t, typeof(T));
        }

        /// <summary>
        /// Serialize the object by protobuf
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj, Type type)
        {
            SerializerBuilder.Build(Model, type);
            var ms = new MemoryStream();
            Model.Serialize(ms, obj);
            return ms.ToArray();
        }

        /// <summary>
        /// Serialize the object by protobuf
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="value"></param>
        public static void Serialize(Stream dest, object value)
        {
            var type = value.GetType();
            SerializerBuilder.Build(Model, type);
            Model.Serialize(dest, value);
        }

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            SerializerBuilder.Build<T>(Model);
            return (T) Deserialize(bytes, typeof(T));
        }

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or length equals 0 then return null)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes, Type type)
        {
            if (bytes == null || bytes.Length == 0) return null;
            SerializerBuilder.Build(Model, type);
            return Deserialize(new MemoryStream(bytes), type);
        }

        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream)
        {
            var type = typeof(T);
            SerializerBuilder.Build<T>(Model);
            return (T) Deserialize(stream, type);
        }

        /// <summary>
        /// Deserialize from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(Stream stream, Type type)
        {
            SerializerBuilder.Build(Model, type);
            if (stream.CanSeek)
                stream.Position = 0;
            return Model.Deserialize(stream, null, type);
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}