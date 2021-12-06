namespace Zaabee.Xml;

public class ZaabeeSerializer : ITextSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue value) =>
        XmlSerializer.Serialize(typeof(TValue), value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        XmlSerializer.Serialize(type, value);

    public TValue DeserializeFromBytes<TValue>(byte[] bytes) =>
        XmlSerializer.Deserialize<TValue>(bytes);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        XmlSerializer.Deserialize(type, bytes);

    public string SerializeToString<TValue>(TValue value) =>
        XmlSerializer.SerializeToXml(value);

    public string SerializeToString(Type type, object? value) =>
        XmlSerializer.SerializeToXml(type, value);

    public TValue DeserializeFromString<TValue>(string text) =>
        XmlSerializer.Deserialize<TValue>(text);

    public object DeserializeFromString(Type type, string text) =>
        XmlSerializer.Deserialize(type, text);

    public Stream? SerializeToStream<TValue>(TValue value) =>
        XmlSerializer.Pack(value);

    public Stream? SerializeToStream(Type type, object? value) =>
        XmlSerializer.Pack(type, value);

    public TValue DeserializeFromStream<TValue>(Stream? stream) =>
        XmlSerializer.Unpack<TValue>(stream);

    public object DeserializeFromStream(Type type, Stream? stream) =>
        XmlSerializer.Unpack(type, stream);
}