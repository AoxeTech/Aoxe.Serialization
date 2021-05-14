using System;
using System.IO;
using ProtoBuf.Meta;
using Zaabee.Extensions;

namespace Zaabee.Protobuf
{
    public static partial class ProtobufSerializer
    {
        private static readonly Lazy<RuntimeTypeModel> Model = new Lazy<RuntimeTypeModel>(() =>
        {
            var typeModel = RuntimeTypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        });

        private static RuntimeTypeModel TypeModel => Model.Value;

        /// <summary>
        /// Serialize the generic object to a memory stream.
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MemoryStream Pack<T>(T t)
        {
            var ms = new MemoryStream();
            Pack(t, ms);
            return ms;
        }

        /// <summary>
        /// Serialize the object to a memory stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static MemoryStream Pack(object obj)
        {
            var ms = new MemoryStream();
            Pack(obj, ms);
            return ms;
        }

        /// <summary>
        /// Serialize the generic object to the stream.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        public static void Pack<T>(T t, Stream stream)
        {
            TypeModel.Serialize(stream, t);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Serialize the object to the stream.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public static void Pack(object obj, Stream stream)
        {
            TypeModel.Serialize(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Deserialize the stream to a generic object.
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Unpack<T>(Stream stream)
        {
            var result = TypeModel.Deserialize<T>(stream);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }

        /// <summary>
        /// Deserialize the stream to an object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static object Unpack(Type type, Stream stream)
        {
            var result = TypeModel.Deserialize(stream, null, type);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}