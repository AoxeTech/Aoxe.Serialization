namespace Zaabee.MessagePack;

public sealed class Serializer : IBytesSerializer, IStreamSerializerAsync
{
    private readonly MessagePackSerializerOptions? _options;

    public Serializer(MessagePackSerializerOptions? options = null) =>
        _options = options;

    public byte[] ToBytes<TValue>(TValue? value) =>
        MessagePackHelper.ToBytes(value, _options);

    public byte[] ToBytes(Type type, object? value) =>
        MessagePackHelper.ToBytes(type, value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes<TValue>(bytes, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes(type, bytes, _options);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MessagePackHelper.ToStream(value, _options);

    public MemoryStream ToStream(Type type, object? value) =>
        MessagePackHelper.ToStream(type, value, _options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        MessagePackHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        MessagePackHelper.Pack(type, value, stream);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MessagePackHelper.FromStream<TValue>(stream, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MessagePackHelper.FromStream(type, stream, _options);

    public Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(value, stream, _options, cancellationToken).AsTask();

    public Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, value, stream, _options, cancellationToken).AsTask();

    public Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? Task.FromResult(default(TValue?))
            : MessagePackHelper.FromStreamAsync<TValue>(stream, _options, cancellationToken).AsTask();

    public Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? Task.FromResult(default(object?))
            : MessagePackHelper.FromStreamAsync(type, stream, _options, cancellationToken).AsTask();
}