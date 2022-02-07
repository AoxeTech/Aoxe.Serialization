namespace Zaabee.Utf8Json;

public class Serializer : IJsonSerializer
{
    private readonly IJsonFormatterResolver? _resolver;

    public Serializer(IJsonFormatterResolver? resolver = null) =>
        _resolver = resolver;

    public byte[] ToBytes<TValue>(TValue? value) =>
        Utf8JsonHelper.ToBytes(value, _resolver);

    public byte[] ToBytes(Type type, object? value) =>
        Utf8JsonHelper.ToBytes(type, value, _resolver);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes<TValue>(bytes, _resolver);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes(type, bytes, _resolver);

    public string ToText<TValue>(TValue? value) =>
        Utf8JsonHelper.ToJson(value, _resolver);

    public string ToText(Type type, object? value) =>
        Utf8JsonHelper.ToJson(type, value, _resolver);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson<TValue>(text, _resolver);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : Utf8JsonHelper.FromJson(type, text, _resolver);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        Utf8JsonHelper.ToStream(value, _resolver);

    public MemoryStream ToStream(Type type, object? value) =>
        Utf8JsonHelper.ToStream(type, value, _resolver);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : Utf8JsonHelper.FromStream<TValue>(stream, _resolver);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : Utf8JsonHelper.FromStream(type, stream, _resolver);

    public string ToJson<TValue>(TValue? value) =>
        Utf8JsonHelper.ToJson(value, _resolver);

    public TValue? FromJson<TValue>(string? json) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : Utf8JsonHelper.FromJson<TValue>(json, _resolver);

    public string ToJson(Type type, object? value) =>
        Utf8JsonHelper.ToJson(type, value, _resolver);

    public object? FromJson(Type type, string? json) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : Utf8JsonHelper.FromJson(type, json, _resolver);
}