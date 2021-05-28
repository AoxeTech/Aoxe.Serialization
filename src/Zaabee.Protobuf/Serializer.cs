using System.IO;
using Zaabee.Extensions;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Protobuf
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            ProtobufSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            ProtobufSerializer.Deserialize<T>(bytes);

        public string BytesToString(byte[] bytes) =>
            bytes.ToBase64String();

        public string SerializeToString<T>(T t) =>
            ProtobufSerializer.SerializeToBase64(t);

        public T DeserializeFromString<T>(string text) =>
            ProtobufSerializer.DeserializeFromBase64<T>(text);

        public byte[] StringToBytes(string text) =>
            text.FromBase64ToBytes();

        public Stream SerializeToStream<T>(T t) =>
            ProtobufSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            ProtobufSerializer.Unpack<T>(stream);
    }
}