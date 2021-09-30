using System;
using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Binary
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            BinarySerializer.Serialize(t);

        public byte[] SerializeToBytes(Type type, object obj) =>
            BinarySerializer.Serialize(obj);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            BinarySerializer.Deserialize<T>(bytes);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            BinarySerializer.Deserialize(bytes);

        public Stream SerializeToStream<T>(T t) =>
            BinarySerializer.Pack(t);

        public Stream SerializeToStream(Type type, object obj) =>
            BinarySerializer.Pack(obj);

        public T DeserializeFromStream<T>(Stream stream) =>
            BinarySerializer.Unpack<T>(stream);

        public object DeserializeFromStream(Type type, Stream stream) =>
            BinarySerializer.Unpack(stream);
    }
}