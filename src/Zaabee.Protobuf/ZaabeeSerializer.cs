using System;
using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Protobuf
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            ProtobufSerializer.Serialize(t);

        public byte[] SerializeToBytes(Type type, object obj) =>
            ProtobufSerializer.Serialize(obj);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            ProtobufSerializer.Deserialize<T>(bytes);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            ProtobufSerializer.Deserialize(type, bytes);

        public Stream SerializeToStream<T>(T t) =>
            ProtobufSerializer.Pack(t);

        public Stream SerializeToStream(Type type, object obj) =>
            ProtobufSerializer.Pack(obj);

        public T DeserializeFromStream<T>(Stream stream) =>
            ProtobufSerializer.Unpack<T>(stream);

        public object DeserializeFromStream(Type type, Stream stream) =>
            ProtobufSerializer.Unpack(type, stream);
    }
}