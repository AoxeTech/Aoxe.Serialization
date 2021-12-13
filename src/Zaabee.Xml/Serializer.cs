namespace Zaabee.Xml;

public class Serializer : ITextSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : XmlHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlHelper.FromBytes<TValue>(bytes!);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : XmlHelper.FromBytes(type, bytes!);

    public string ToText<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : XmlHelper.ToXml(value);

    public string ToText(Type type, object? value) =>
        value is null
            ? string.Empty
            : XmlHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml(type, text);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : XmlHelper.ToStream(value);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : XmlHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlHelper.FromStream<TValue>(stream!);

    public object? FromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : XmlHelper.FromStream(type, stream!);
}