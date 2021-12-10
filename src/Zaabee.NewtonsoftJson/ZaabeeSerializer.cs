namespace Zaabee.NewtonsoftJson;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly JsonSerializerSettings? _settings;
    private readonly Encoding? _encoding;

    public ZaabeeSerializer(JsonSerializerSettings? settings = null, Encoding? encoding = null) =>
        (_settings, _encoding) = (settings, encoding);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonHelper.ToBytes(value, _settings, _encoding);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonHelper.ToBytes(type, value, _settings, _encoding);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonHelper.FromBytes<TValue>(bytes!, _settings, _encoding);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonHelper.FromBytes(type, bytes!, _settings, _encoding);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonHelper.ToJson(value, _settings);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonHelper.ToJson(type, value, _settings);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson<TValue>(text!, _settings);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson(type, text!, _settings);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonHelper.ToStream(value, _settings, _encoding);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonHelper.ToStream(type, value, _settings, _encoding);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonHelper.FromStream<TValue>(stream, _settings, _encoding);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonHelper.FromStream(type, stream, _settings, _encoding);
}