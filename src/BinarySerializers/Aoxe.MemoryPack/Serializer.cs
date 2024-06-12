namespace Aoxe.MemoryPack;

public sealed class Serializer(MemoryPackSerializerOptions? options = null)
    : IBytesSerializer,
        IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) => MemoryPackHelper.ToBytes(value, options);

    public byte[] ToBytes(Type type, object? value) =>
        MemoryPackHelper.ToBytes(type, value, options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MemoryPackHelper.FromBytes<TValue>(bytes, options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MemoryPackHelper.FromBytes(type, bytes, options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        MemoryPackHelper.Pack(value, stream, options);

    public void Pack(Type type, object? value, Stream? stream) =>
        MemoryPackHelper.Pack(type, value, stream, options);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MemoryPackHelper.ToStream(value, options);

    public MemoryStream ToStream(Type type, object? value) =>
        MemoryPackHelper.ToStream(type, value, options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MemoryPackHelper.FromStream<TValue>(stream, options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MemoryPackHelper.FromStream(type, stream, options);

    public ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => MemoryPackHelper.PackAsync(value, stream, options, cancellationToken);

    public ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => MemoryPackHelper.PackAsync(type, value, stream, options, cancellationToken);

    public ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? ValueTask.FromResult(default(TValue?))
            : MemoryPackHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? ValueTask.FromResult(default(object?))
            : MemoryPackHelper.FromStreamAsync(type, stream, options, cancellationToken);
}
