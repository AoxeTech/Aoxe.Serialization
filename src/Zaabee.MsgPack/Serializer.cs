using System.IO;
using Zaabee.Extensions;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.MsgPack
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            MsgPackSerializer.Serialize(t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            MsgPackSerializer.Deserialize<T>(bytes);

        public string BytesToString(byte[] bytes) =>
            bytes.ToBase64String();

        public string SerializeToString<T>(T t) =>
            MsgPackSerializer.SerializeToBase64(t);

        public T DeserializeFromString<T>(string text) =>
            MsgPackSerializer.DeserializeFromBase64<T>(text);

        public byte[] StringToBytes(string text) =>
            text.FromBase64ToBytes();

        public Stream SerializeToStream<T>(T t) =>
            MsgPackSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            MsgPackSerializer.Unpack<T>(stream);
    }
}