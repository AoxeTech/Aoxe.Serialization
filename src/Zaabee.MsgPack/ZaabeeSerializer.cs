using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.MsgPack
{
    public class ZaabeeSerializer : IBytesSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            MsgPackSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            MsgPackSerializer.Deserialize<T>(bytes);

        public Stream SerializeToStream<T>(T t) =>
            MsgPackSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            MsgPackSerializer.Unpack<T>(stream);
    }
}