using System;
using System.IO;
using ProtoBuf.Meta;

namespace Zaabee.Protobuf
{
    public static class ProtobufSerializer
    {
        private static readonly Lazy<RuntimeTypeModel> Model = new Lazy<RuntimeTypeModel>(() =>
        {
            var typeModel = RuntimeTypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        });

        private static RuntimeTypeModel TypeModel => Model.Value;

        #region Bytes

        public static byte[] Serialize(object obj)
        {
            using var ms = Pack(obj);
            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes) => (T) Deserialize(typeof(T), bytes);

        public static object Deserialize(Type type, byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Unpack(type, ms);
        }

        #endregion

        #region Stream

        public static MemoryStream Pack(object obj)
        {
            var ms = new MemoryStream();
            Pack(obj, ms);
            return ms;
        }

        public static void Pack(object obj, Stream stream) => TypeModel.Serialize(stream, obj);

        public static T Unpack<T>(Stream stream)=>(T) Unpack(typeof(T), stream);

        public static object Unpack(Type type, Stream stream)
        {
            if (stream.CanSeek && stream.Position > 0)
                stream.Position = 0;
            return TypeModel.Deserialize(stream, null, type);
        }

        #endregion
    }
}