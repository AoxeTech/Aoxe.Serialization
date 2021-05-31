using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.ZeroFormatter
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            ZeroSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            ZeroSerializer.Deserialize<T>(bytes);

        public Stream SerializeToStream<T>(T t) =>
            ZeroSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            ZeroSerializer.Unpack<T>(stream);
    }
}