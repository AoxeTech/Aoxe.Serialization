namespace Zaabee.Utf8Json;

public class Serializer : ITextSerializer
{
    private readonly IJsonFormatterResolver? _resolver;

    public Serializer(IJsonFormatterResolver? resolver = null) =>
        _resolver = resolver;

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonHelper.ToBytes(value, _resolver);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonHelper.ToBytes(type, value, _resolver);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonHelper.FromBytes<TValue>(bytes!, _resolver);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonHelper.FromBytes(type, bytes!, _resolver);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : Utf8JsonHelper.ToJson(value, _resolver);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : Utf8JsonHelper.ToJson(type, value, _resolver);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson<TValue>(text!, _resolver);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson(type, text!, _resolver);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonHelper.ToStream(value, _resolver);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonHelper.ToStream(type, value, _resolver);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonHelper.FromStream<TValue>(stream, _resolver);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonHelper.FromStream(type, stream, _resolver);
}