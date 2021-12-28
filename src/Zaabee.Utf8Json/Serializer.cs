namespace Zaabee.Utf8Json;

public class Serializer : ITextSerializer
{
    private readonly IJsonFormatterResolver? _resolver;

    public Serializer(IJsonFormatterResolver? resolver = null) =>
        _resolver = resolver;

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonHelper.ToBytes(value, _resolver);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : Utf8JsonHelper.ToBytes(type, value, _resolver);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes<TValue>(bytes, _resolver);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes(type, bytes, _resolver);

    public string ToText<TValue>(TValue? value) =>
        value is null
            ? string.Empty
            : Utf8JsonHelper.ToJson(value, _resolver);

    public string ToText(Type type, object? value) =>
        value is null
            ? string.Empty
            : Utf8JsonHelper.ToJson(type, value, _resolver);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson<TValue>(text, _resolver);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson(type, text, _resolver);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonHelper.ToStream(value, _resolver);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : Utf8JsonHelper.ToStream(type, value, _resolver);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : Utf8JsonHelper.FromStream<TValue>(stream, _resolver);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : Utf8JsonHelper.FromStream(type, stream, _resolver);
}