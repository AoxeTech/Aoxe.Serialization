using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.MessagePack
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            MessagePackCSharpSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            MessagePackCSharpSerializer.Deserialize<T>(bytes);

        public Stream SerializeToStream<T>(T t) =>
            MessagePackCSharpSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            MessagePackCSharpSerializer.Unpack<T>(stream);
    }
}