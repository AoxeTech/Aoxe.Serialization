namespace Aoxe.Utf8Json;

public sealed class Serializer(IJsonFormatterResolver? resolver = null)
    : IJsonSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) => Utf8JsonHelper.ToBytes(value, resolver);

    public byte[] ToBytes(Type type, object? value) =>
        Utf8JsonHelper.ToBytes(type, value, resolver);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes<TValue>(bytes, resolver);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : Utf8JsonHelper.FromBytes(type, bytes, resolver);

    public string ToText<TValue>(TValue? value) => Utf8JsonHelper.ToJson(value, resolver);

    public string ToText(Type type, object? value) => Utf8JsonHelper.ToJson(type, value, resolver);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : Utf8JsonHelper.FromJson<TValue>(text, resolver);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text) ? default : Utf8JsonHelper.FromJson(type, text, resolver);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public void Pack(Type type, object? value, Stream? stream) =>
        Utf8JsonHelper.Pack(type, value, stream, resolver);

    public MemoryStream ToStream<TValue>(TValue? value) => Utf8JsonHelper.ToStream(value, resolver);

    public MemoryStream ToStream(Type type, object? value) =>
        Utf8JsonHelper.ToStream(type, value, resolver);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : Utf8JsonHelper.FromStream<TValue>(stream, resolver);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : Utf8JsonHelper.FromStream(type, stream, resolver);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => Utf8JsonHelper.PackAsync(value, stream, resolver);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => Utf8JsonHelper.PackAsync(type, value, stream, resolver);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : Utf8JsonHelper.FromStreamAsync<TValue>(stream, resolver);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : Utf8JsonHelper.FromStreamAsync(type, stream, resolver);
}
