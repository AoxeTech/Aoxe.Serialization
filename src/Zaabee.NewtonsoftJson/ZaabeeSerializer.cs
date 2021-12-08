namespace Zaabee.NewtonsoftJson;

public class ZaabeeSerializer : ITextSerializer
{
    private readonly JsonSerializerSettings? _settings;
    private readonly Encoding _encoding;

    public ZaabeeSerializer(JsonSerializerSettings? settings = null, Encoding? encoding = null) =>
        (_encoding, _settings) = (encoding ?? NewtonsoftJsonHelper.DefaultEncoding, settings);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonSerializer.Serialize(value, _encoding, _settings);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonSerializer.Serialize(type, value, _encoding, _settings);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Deserialize<TValue>(bytes!, _encoding, _settings);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Deserialize(type, bytes!, _encoding, _settings);

    public string SerializeToString<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonSerializer.SerializeToJson(value, _settings);

    public string SerializeToString(Type type, object? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonSerializer.SerializeToJson(type, value, _settings);

    public TValue? DeserializeFromString<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonSerializer.Deserialize<TValue>(text!, _settings);

    public object? DeserializeFromString(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonSerializer.Deserialize(type, text!, _settings);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonSerializer.Pack(value, _encoding, _settings);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonSerializer.Pack(type, value, _encoding, _settings);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Unpack<TValue>(stream, _encoding, _settings);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Unpack(type, stream, _encoding, _settings);
}