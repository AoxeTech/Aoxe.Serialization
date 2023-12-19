namespace Zaabee.MessagePack;

public sealed class Serializer(MessagePackSerializerOptions? options = null)
    : IBytesSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) => MessagePackHelper.ToBytes(value, options);

    public byte[] ToBytes(Type type, object? value) =>
        MessagePackHelper.ToBytes(type, value, options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes<TValue>(bytes, options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes(type, bytes, options);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MessagePackHelper.ToStream(value, options);

    public MemoryStream ToStream(Type type, object? value) =>
        MessagePackHelper.ToStream(type, value, options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        MessagePackHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        MessagePackHelper.Pack(type, value, stream);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MessagePackHelper.FromStream<TValue>(stream, options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MessagePackHelper.FromStream(type, stream, options);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<TValue?>(default(TValue?))
            : MessagePackHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? new ValueTask<object?>(default(object?))
            : MessagePackHelper.FromStreamAsync(type, stream, options, cancellationToken);
}
