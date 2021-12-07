namespace Zaabee.Utf8Json;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly IJsonFormatterResolver? _resolver;

    public ZaabeeSerializer(IJsonFormatterResolver? resolver = null) =>
        _resolver = resolver;

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonSerializer.Serialize(value, _resolver);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonSerializer.Serialize(type, value, _resolver);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Deserialize<TValue>(bytes!, _resolver);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Deserialize(type, bytes!, _resolver);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : Utf8JsonSerializer.SerializeToJson(value, _resolver);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : Utf8JsonSerializer.SerializeToJson(type, value, _resolver);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonSerializer.Deserialize<TValue>(text!, _resolver);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonSerializer.Deserialize(type, text!, _resolver);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonSerializer.Pack(value, _resolver);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonSerializer.Pack(type, value, _resolver);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Unpack<TValue>(stream, _resolver);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Unpack(type, stream, _resolver);
}