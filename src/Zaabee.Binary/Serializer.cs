using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Binary
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            BinarySerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            BinarySerializer.Deserialize<T>(bytes);

        public Stream SerializeToStream<T>(T t) =>
            BinarySerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            BinarySerializer.Unpack<T>(stream);
    }
}