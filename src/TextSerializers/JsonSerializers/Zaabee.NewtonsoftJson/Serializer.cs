namespace Zaabee.NewtonsoftJson;

public sealed class Serializer(JsonSerializerSettings? settings = null, Encoding? encoding = null)
    : IJsonSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        NewtonsoftJsonHelper.ToBytes(value, settings, encoding);

    public byte[] ToBytes(Type type, object? value) =>
        NewtonsoftJsonHelper.ToBytes(type, value, settings, encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromBytes<TValue>(bytes, settings, encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : NewtonsoftJsonHelper.FromBytes(type, bytes, settings, encoding);

    public string ToText<TValue>(TValue? value) => NewtonsoftJsonHelper.ToJson(value, settings);

    public string ToText(Type type, object? value) =>
        NewtonsoftJsonHelper.ToJson(type, value, settings);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson<TValue>(text, settings);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : NewtonsoftJsonHelper.FromJson(type, text, settings);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        NewtonsoftJsonHelper.Pack(value, stream, settings, encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        NewtonsoftJsonHelper.Pack(type, value, stream, settings, encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        NewtonsoftJsonHelper.ToStream(value, settings, encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        NewtonsoftJsonHelper.ToStream(type, value, settings, encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : NewtonsoftJsonHelper.FromStream<TValue>(stream, settings, encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : NewtonsoftJsonHelper.FromStream(type, stream, settings, encoding);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : NewtonsoftJsonHelper.FromStreamAsync<TValue>(
                stream,
                settings,
                encoding,
                cancellationToken
            );

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : NewtonsoftJsonHelper.FromStreamAsync(
                type,
                stream,
                settings,
                encoding,
                cancellationToken
            );
}
