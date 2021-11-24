namespace Zaabee.Utf8Json;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly IJsonFormatterResolver _resolver;

    public ZaabeeSerializer(IJsonFormatterResolver resolver = null) =>
        _resolver = resolver;

    public byte[] SerializeToBytes<T>(T t) =>
        Utf8JsonSerializer.Serialize(t, _resolver);

    public byte[] SerializeToBytes(Type type, object obj) =>
        Utf8JsonSerializer.Serialize(type, obj, _resolver);

    public T DeserializeFromBytes<T>(byte[] bytes) =>
        Utf8JsonSerializer.Deserialize<T>(bytes, _resolver);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        Utf8JsonSerializer.Deserialize(type, bytes, _resolver);

    public string SerializeToString<T>(T t) =>
        Utf8JsonSerializer.SerializeToJson(t, _resolver);

    public string SerializeToString(Type type, object obj) =>
        Utf8JsonSerializer.SerializeToJson(type, obj, _resolver);

    public T DeserializeFromString<T>(string text) =>
        Utf8JsonSerializer.Deserialize<T>(text, _resolver);

    public object DeserializeFromString(Type type, string text) =>
        Utf8JsonSerializer.Deserialize(type, text, _resolver);

    public Stream SerializeToStream<T>(T t) =>
        Utf8JsonSerializer.Pack(t, _resolver);

    public Stream SerializeToStream(Type type, object obj) =>
        Utf8JsonSerializer.Pack(type, obj, _resolver);

    public T DeserializeFromStream<T>(Stream stream) =>
        Utf8JsonSerializer.Unpack<T>(stream, _resolver);

    public object DeserializeFromStream(Type type, Stream stream) =>
        Utf8JsonSerializer.Unpack(type, stream, _resolver);
}