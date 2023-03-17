namespace Zaabee.SystemTextJson;

public sealed class Serializer : IJsonSerializer, IStreamSerializerAsync
{
    private readonly JsonSerializerOptions? _options;

    public Serializer(JsonSerializerOptions? options = null) =>
        _options = options;

    public MemoryStream ToStream<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToStream(value, _options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SystemTextJsonHelper.FromStream<TValue>(stream, _options);

    public MemoryStream ToStream(Type type, object? value) =>
        SystemTextJsonHelper.ToStream(type, value, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SystemTextJsonHelper.FromStream(type, stream, _options);

    public byte[] ToBytes<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToBytes(value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes<TValue>(bytes, _options);

    public byte[] ToBytes(Type type, object? value) =>
        SystemTextJsonHelper.ToBytes(type, value, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes(type, bytes, _options);

    public string ToText<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToJson(value, _options);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SystemTextJsonHelper.FromJson<TValue>(text, _options);

    public string ToText(Type type, object? value) =>
        SystemTextJsonHelper.ToJson(type, value, _options);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SystemTextJsonHelper.FromJson(type, text, _options);

    public string ToJson<TValue>(TValue? value) =>
        ToText(value);

    public TValue? FromJson<TValue>(string? json) =>
        FromText<TValue>(json);

    public string ToJson(Type type, object? value) =>
        ToText(type, value);

    public object? FromJson(Type type, string? json) =>
        FromText(type, json);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await SystemTextJsonHelper.PackAsync(value, stream, _options, cancellationToken);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await SystemTextJsonHelper.PackAsync(value, stream, _options, cancellationToken);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await SystemTextJsonHelper.FromStreamAsync<TValue>(stream, _options, cancellationToken);

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await SystemTextJsonHelper.FromStreamAsync(type, stream, _options, cancellationToken);
}