using System;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufHelper
    {
        private static readonly Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model => model.Value;

        /// <summary>
        /// Serialize the object to byte[](if the generic object == null then return new byte[0])
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">generic object</param>
        /// <returns>bytes</returns>
        public static byte[] Serialize<T>(T t) =>
            t is null ? new byte[0] : Serialize((object) t);

        /// <summary>
        /// Serialize the object to byte[](if the object == null then return new byte[0])
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            if (obj is null) return new byte[0];
            var ms = new MemoryStream();
            Model.Serialize(ms, obj);
            return ms.ToArray();
        }

        /// <summary>
        /// Serialize the object by protobuf
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="value"></param>
        public static void Serialize(Stream dest, object value) =>
            Model.Serialize(dest, value);

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or its length equals 0 then return default(T))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return default(T);
            return (T) Deserialize(bytes, typeof(T));
        }

        /// <summary>
        /// Deserialize from protobuf bytes(if the bytes is null or its length equals 0 then return null)
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] bytes, Type type)
        {
            if (bytes == null || bytes.Length == 0) return null;
            return Deserialize(new MemoryStream(bytes), type);
        }

        /// <summary>
        /// Deserialize from stream(if the stream is null or its length equals 0 then return default(T))
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream)
        {
            if (stream == null || stream.Length == 0) return default(T);
            var type = typeof(T);
            return (T) Deserialize(stream, type);
        }

        /// <summary>
        /// Deserialize from stream(if the stream is null or its length equals 0 then return null)
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(Stream stream, Type type)
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