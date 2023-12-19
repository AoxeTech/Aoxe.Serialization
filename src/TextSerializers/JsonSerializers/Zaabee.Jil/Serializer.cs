namespace Zaabee.Jil;

public sealed class Serializer(Options? options = null, Encoding? encoding = null)
    : IJsonSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) => JilHelper.ToBytes(value, options, encoding);

    public byte[] ToBytes(Type type, object? value) => JilHelper.ToBytes(value, options, encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes<TValue>(bytes, options, encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes(type, bytes, options, encoding);

    public string ToText<TValue>(TValue? value) => JilHelper.ToJson(value, options);

    public string ToText(Type type, object? value) => JilHelper.ToJson(value, options);

    public TValue? FromText<TValue>(string? text) =>
        text.IsNullOrWhiteSpace() ? default : JilHelper.FromJson<TValue>(text, options);

    public object? FromText(Type type, string? text) =>
        text.IsNullOrWhiteSpace() ? default : JilHelper.FromJson(type, text, options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        JilHelper.Pack(value, stream, options, encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        JilHelper.Pack(value, stream, options, encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        JilHelper.ToStream(value, options, encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        JilHelper.ToStream(value, options, encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : JilHelper.FromStream<TValue>(stream, options, encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : JilHelper.FromStream(type, stream, options, encoding);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, options, encoding, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, options, encoding, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : JilHelper.FromStreamAsync<TValue>(stream, options, encoding, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : JilHelper.FromStreamAsync(type, stream, options, encoding, cancellationToken);
}
