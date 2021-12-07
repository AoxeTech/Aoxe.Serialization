namespace Zaabee.SystemTextJson;

public class  ZaabeeSerializer : ITextSerializer
{
    private readonly JsonSerializerOptions? _options;

    public ZaabeeSerializer(JsonSerializerOptions? options = null) =>
        _options = options;

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : SystemTextJsonSerializer.Pack(value, _options);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : SystemTextJsonSerializer.Unpack<TValue>(stream!, _options);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : SystemTextJsonSerializer.Pack(type, value, _options);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : SystemTextJsonSerializer.Unpack(type, stream!, _options);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : SystemTextJsonSerializer.Serialize(value, _options);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : SystemTextJsonSerializer.Deserialize<TValue>(bytes, _options);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : SystemTextJsonSerializer.Serialize(type, value, _options);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : SystemTextJsonSerializer.Deserialize(type, bytes, _options);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : SystemTextJsonSerializer.SerializeToJson(value, _options);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonSerializer.Deserialize<TValue>(text!, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : SystemTextJsonSerializer.SerializeToJson(type, value, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonSerializer.Deserialize(type, text!, _options);
}