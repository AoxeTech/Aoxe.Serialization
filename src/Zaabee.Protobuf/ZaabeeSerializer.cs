using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Protobuf
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            ProtobufSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            ProtobufSerializer.Deserialize<T>(bytes);

        public Stream SerializeToStream<T>(T t) =>
            ProtobufSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            ProtobufSerializer.Unpack<T>(stream);
    }
}