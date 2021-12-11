namespace Zaabee.Xml;

public class Serializer : ITextSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlHelper.ToBytes(typeof(TValue), value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlHelper.ToBytes(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlHelper.FromBytes<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlHelper.FromBytes(type, bytes!);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : XmlHelper.ToXml(value);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : XmlHelper.ToXml(type, value);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml<TValue>(text!);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml(type, text!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : XmlHelper.ToStream(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : XmlHelper.ToStream(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlHelper.FromStream<TValue>(stream!);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlHelper.FromStream(type, stream!);
}