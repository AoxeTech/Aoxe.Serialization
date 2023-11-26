namespace Zaabee.Jil;

public sealed class Serializer : IJsonSerializer, IStreamSerializerAsync
{
    private readonly Options? _options;
    private readonly Encoding? _encoding;

    public Serializer(Options? options = null, Encoding? encoding = null) =>
        (_options, _encoding) = (options, encoding);

    public byte[] ToBytes<TValue>(TValue? value) => JilHelper.ToBytes(value, _options, _encoding);

    public byte[] ToBytes(Type type, object? value) =>
        JilHelper.ToBytes(value, _options, _encoding);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes<TValue>(bytes, _options, _encoding);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : JilHelper.FromBytes(type, bytes, _options, _encoding);

    public string ToText<TValue>(TValue? value) => JilHelper.ToJson(value, _options);

    public string ToText(Type type, object? value) => JilHelper.ToJson(value, _options);

    public TValue? FromText<TValue>(string? text) =>
        text.IsNullOrWhiteSpace() ? default : JilHelper.FromJson<TValue>(text, _options);

    public object? FromText(Type type, string? text) =>
        text.IsNullOrWhiteSpace() ? default : JilHelper.FromJson(type, text, _options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        JilHelper.Pack(value, stream, _options, _encoding);

    public void Pack(Type type, object? value, Stream? stream) =>
        JilHelper.Pack(value, stream, _options, _encoding);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        JilHelper.ToStream(value, _options, _encoding);

    public MemoryStream ToStream(Type type, object? value) =>
        JilHelper.ToStream(value, _options, _encoding);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : JilHelper.FromStream<TValue>(stream, _options, _encoding);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : JilHelper.FromStream(type, stream, _options, _encoding);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, _options, _encoding, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, _options, _encoding, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : JilHelper.FromStreamAsync<TValue>(stream, _options, _encoding, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : JilHelper.FromStreamAsync(type, stream, _options, _encoding, cancellationToken);
}
