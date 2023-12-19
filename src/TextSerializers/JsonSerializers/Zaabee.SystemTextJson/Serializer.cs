namespace Zaabee.SystemTextJson;

public sealed class Serializer(JsonSerializerOptions? options = null)
    : IJsonSerializer,
        IStreamSerializerAsync
{
    public MemoryStream ToStream<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToStream(value, options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        SystemTextJsonHelper.Pack(value, stream, options);

    public void Pack(Type type, object? value, Stream? stream) =>
        SystemTextJsonHelper.Pack(type, value, stream, options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SystemTextJsonHelper.FromStream<TValue>(stream, options);

    public MemoryStream ToStream(Type type, object? value) =>
        SystemTextJsonHelper.ToStream(type, value, options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SystemTextJsonHelper.FromStream(type, stream, options);

    public byte[] ToBytes<TValue>(TValue? value) => SystemTextJsonHelper.ToBytes(value, options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes<TValue>(bytes, options);

    public byte[] ToBytes(Type type, object? value) =>
        SystemTextJsonHelper.ToBytes(type, value, options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes(type, bytes, options);

    public string ToText<TValue>(TValue? value) => SystemTextJsonHelper.ToJson(value, options);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SystemTextJsonHelper.FromJson<TValue>(text, options);

    public string ToText(Type type, object? value) =>
        SystemTextJsonHelper.ToJson(type, value, options);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SystemTextJsonHelper.FromJson(type, text, options);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => SystemTextJsonHelper.PackAsync(value, stream, options, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => SystemTextJsonHelper.PackAsync(type, value, stream, options, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : SystemTextJsonHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : SystemTextJsonHelper.FromStreamAsync(type, stream, options, cancellationToken);
}
