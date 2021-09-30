using System;
using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.MsgPack
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            MsgPackSerializer.Serialize(t);

        public byte[] SerializeToBytes(Type type, object obj) =>
            MsgPackSerializer.Serialize(type, obj);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            MsgPackSerializer.Deserialize<T>(bytes);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            MsgPackSerializer.Deserialize(type, bytes);

        public Stream SerializeToStream<T>(T t) =>
            MsgPackSerializer.Pack(t);

        public Stream SerializeToStream(Type type, object obj) =>
            MsgPackSerializer.Pack(type, obj);

        public T DeserializeFromStream<T>(Stream stream) =>
            MsgPackSerializer.Unpack<T>(stream);

        public object DeserializeFromStream(Type type, Stream stream) =>
            MsgPackSerializer.Unpack(type, stream);
    }
}