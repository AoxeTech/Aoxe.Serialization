using System;
using System.IO;
using Zaabee.Serializer.Abstractions;

namespace Zaabee.Xml
{
    public class ZaabeeSerializer : ITextSerializer
    {
        public byte[] SerializeToBytes<T>(T t) =>
            XmlSerializer.Serialize(typeof(T), t);

        public byte[] SerializeToBytes(Type type, object obj) =>
            XmlSerializer.Serialize(type, obj);

        public T DeserializeFromBytes<T>(byte[] bytes) =>
            XmlSerializer.Deserialize<T>(bytes);

        public object DeserializeFromBytes(Type type, byte[] bytes) =>
            XmlSerializer.Deserialize(type, bytes);

        public string SerializeToString<T>(T t) =>
            XmlSerializer.SerializeToXml(t);

        public string SerializeToString(Type type, object obj) =>
            XmlSerializer.SerializeToXml(type, obj);

        public T DeserializeFromString<T>(string text) =>
            XmlSerializer.Deserialize<T>(text);

        public object DeserializeFromString(Type type, string text) =>
            XmlSerializer.Deserialize(type, text);

        public Stream SerializeToStream<T>(T t) =>
            XmlSerializer.Pack(t);

        public Stream SerializeToStream(Type type, object obj) =>
            XmlSerializer.Pack(type, obj);

        public T DeserializeFromStream<T>(Stream stream) =>
            XmlSerializer.Unpack<T>(stream);

        public object DeserializeFromStream(Type type, Stream stream) =>
            XmlSerializer.Unpack(type, stream);
    }
}