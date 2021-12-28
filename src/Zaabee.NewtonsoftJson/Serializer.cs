namespace Zaabee.NewtonsoftJson;

public class Serializer : ITextSerializer
{
    private readonly JsonSerializerSettings? _settings;
    private readonly Encoding? _encoding;

    public Serializer(JsonSerializerSettings? settings = null, Encoding? encoding = null) =>
        (_settings, _encoding) = (settings, encoding);

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonHelper.ToBytes(value, _settings, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonHelper.ToBytes(type, value, _settings, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromBytes<TValue>(bytes, _settings, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromBytes(type, bytes, _settings, _encoding);

    public string ToText<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonHelper.ToJson(value, _settings);

    public string ToText(Type type, object? value) =>
        value is null
            ? string.Empty
            : NewtonsoftJsonHelper.ToJson(type, value, _settings);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson<TValue>(text, _settings);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson(type, text, _settings);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonHelper.ToStream(value, _settings, _encoding);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonHelper.ToStream(type, value, _settings, _encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromStream<TValue>(stream, _settings, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromStream(type, stream, _settings, _encoding);
}