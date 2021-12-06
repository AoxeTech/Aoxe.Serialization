namespace Zaabee.Utf8Json;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly IJsonFormatterResolver _resolver;

    public ZaabeeSerializer(IJsonFormatterResolver resolver = null) =>
        _resolver = resolver;

    public byte[] SerializeToBytes<TValue>(TValue value) =>
        Utf8JsonSerializer.Serialize(value, _resolver);

    public byte[] SerializeToBytes(Type type, object? value) =>
        Utf8JsonSerializer.Serialize(type, value, _resolver);

    public TValue DeserializeFromBytes<TValue>(byte[] bytes) =>
        Utf8JsonSerializer.Deserialize<TValue>(bytes, _resolver);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        Utf8JsonSerializer.Deserialize(type, bytes, _resolver);

    public string SerializeToString<TValue>(TValue value) =>
        Utf8JsonSerializer.SerializeToJson(value, _resolver);

    public string SerializeToString(Type type, object? value) =>
        Utf8JsonSerializer.SerializeToJson(type, value, _resolver);

    public TValue DeserializeFromString<TValue>(string text) =>
        Utf8JsonSerializer.Deserialize<TValue>(text, _resolver);

    public object DeserializeFromString(Type type, string text) =>
        Utf8JsonSerializer.Deserialize(type, text, _resolver);

    public Stream? SerializeToStream<TValue>(TValue value) =>
        Utf8JsonSerializer.Pack(value, _resolver);

    public Stream? SerializeToStream(Type type, object? value) =>
        Utf8JsonSerializer.Pack(type, value, _resolver);

    public TValue DeserializeFromStream<TValue>(Stream? stream) =>
        Utf8JsonSerializer.Unpack<TValue>(stream, _resolver);

    public object DeserializeFromStream(Type type, Stream? stream) =>
        Utf8JsonSerializer.Unpack(type, stream, _resolver);
}