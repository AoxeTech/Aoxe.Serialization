namespace Zaabee.SharpSerializer;

public sealed class Serializer : IXmlSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        SharpSerializerHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        SharpSerializerHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SharpSerializerHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SharpSerializerHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        SharpSerializerHelper.ToXml(value);

    public string ToText(Type type, object? value) =>
        SharpSerializerHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SharpSerializerHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SharpSerializerHelper.FromXml(type, text);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        SharpSerializerHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        SharpSerializerHelper.Pack(type, value, stream);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        SharpSerializerHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        SharpSerializerHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SharpSerializerHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SharpSerializerHelper.FromStream(type, stream);
}