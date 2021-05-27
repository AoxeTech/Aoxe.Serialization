using System.IO;
using Zaabee.Extensions;
using Zaabee.Serializer.Abstraction;

namespace Zaabee.ZeroFormatter
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            ZeroSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            ZeroSerializer.Deserialize<T>(bytes);

        public string BytesToString(byte[] bytes) =>
            bytes.ToBase64String();

        public string SerializeToString<T>(T t) =>
            ZeroSerializer.SerializeToBase64(t);

        public T DeserializeFromString<T>(string text) =>
            ZeroSerializer.DeserializeFromBase64<T>(text);

        public byte[] StringToBytes(string text) =>
            text.FromBase64ToBytes();

        public Stream SerializeToStream<T>(T t) =>
            ZeroSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            ZeroSerializer.Unpack<T>(stream);
    }
}