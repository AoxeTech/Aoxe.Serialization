using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Xml
{
    public class Serializer : ITextSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            XmlSerializer.Serialize(typeof(T), t);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            XmlSerializer.Deserialize<T>(bytes);

        public string SerializeToString<T>(T t) =>
            XmlSerializer.SerializeToXml(t);

        public T DeserializeFromString<T>(string text) =>
            XmlSerializer.Deserialize<T>(text);

        public Stream SerializeToStream<T>(T t) =>
            XmlSerializer.Pack(t);

        public T DeserializeFromStream<T>(Stream stream) =>
            XmlSerializer.Unpack<T>(stream);
    }
}