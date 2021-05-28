using System.IO;
using Zaabee.Extensions;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Binary
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            BinarySerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            BinarySerializer.Deserialize<T>(bytes);

        public string BytesToString(byte[] bytes) =>
            bytes.ToBase64String();

        public string SerializeToString<T>(T t) =>
            BinarySerializer.SerializeToBase64(t);

        public T DeserializeFromString<T>(string text) =>
            BinarySerializer.DeserializeFromBase64<T>(text);

        public byte[] StringToBytes(string text) =>
            text.FromBase64ToBytes();

        public Stream SerializeToStream<T>(T t) =>
            BinarySerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            BinarySerializer.Unpack<T>(stream);
    }
}