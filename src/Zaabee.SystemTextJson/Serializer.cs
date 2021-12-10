namespace Zaabee.SystemTextJson;

public class  Serializer : ITextSerializer
{
    private readonly JsonSerializerOptions? _options;

    public Serializer(JsonSerializerOptions? options = null) =>
        _options = options;

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : SystemTextJsonHelper.ToStream(value, _options);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : SystemTextJsonHelper.FromStream<TValue>(stream!, _options);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : SystemTextJsonHelper.ToStream(type, value, _options);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : SystemTextJsonHelper.FromStream(type, stream!, _options);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : SystemTextJsonHelper.ToBytes(value, _options);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : SystemTextJsonHelper.FromBytes<TValue>(bytes, _options);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : SystemTextJsonHelper.ToBytes(type, value, _options);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : SystemTextJsonHelper.FromBytes(type, bytes, _options);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : SystemTextJsonHelper.ToJson(value, _options);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonHelper.FromJson<TValue>(text!, _options);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : SystemTextJsonHelper.ToJson(type, value, _options);

    public object? DeserializeFromString(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonHelper.FromJson(type, text!, _options);
}