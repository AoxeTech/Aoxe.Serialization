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

        public static MemoryStream Pack(object obj)
        {
            var ms = new MemoryStream();
            Pack(obj, ms);
            return ms;
        }

        public static void Pack(object obj, Stream stream)
        {
            TypeModel.Serialize(stream, obj);
            stream.TrySeek(0, SeekOrigin.Begin);
        }

        public static T Unpack<T>(Stream stream) => (T) Unpack(typeof(T), stream);

        public static object Unpack(Type type, Stream stream)
        {
            var result = TypeModel.Deserialize(stream, null, type);
            stream.TrySeek(0, SeekOrigin.Begin);
            return result;
        }
    }
}