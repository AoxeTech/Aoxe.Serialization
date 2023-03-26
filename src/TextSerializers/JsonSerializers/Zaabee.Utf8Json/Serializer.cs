namespace Zaabee.Utf8Json;

public sealed class Serializer : IJsonSerializer, IStreamSerializerAsync
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
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : Utf8JsonHelper.FromStream<TValue>(stream, _resolver);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : Utf8JsonHelper.FromStream(type, stream, _resolver);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await Utf8JsonHelper.PackAsync(value, stream, _resolver);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await Utf8JsonHelper.PackAsync(value, stream, _resolver);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await Utf8JsonHelper.FromStreamAsync<TValue>(stream, _resolver);

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await Utf8JsonHelper.FromStreamAsync(type, stream, _resolver);
}