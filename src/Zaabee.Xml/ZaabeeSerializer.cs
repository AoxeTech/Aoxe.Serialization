namespace Zaabee.Xml;

public class ZaabeeSerializer : ITextSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlSerializer.Serialize(typeof(TValue), value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlSerializer.Serialize(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlSerializer.Deserialize<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlSerializer.Deserialize(type, bytes!);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : XmlSerializer.SerializeToXml(value);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : XmlSerializer.SerializeToXml(type, value);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlSerializer.Deserialize<TValue>(text!);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlSerializer.Deserialize(type, text!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : XmlSerializer.Pack(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : XmlSerializer.Pack(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlSerializer.Unpack<TValue>(stream!);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlSerializer.Unpack(type, stream!);
}