namespace Zaabee.MemoryPack;

public sealed class Serializer : IBytesSerializer, IStreamSerializerAsync
{
    private readonly MemoryPackSerializerOptions? _options;

    public Serializer(MemoryPackSerializerOptions? options = null) =>
        _options = options;

    public byte[] ToBytes<TValue>(TValue? value) =>
        MemoryPackHelper.ToBytes(value, _options);

    public byte[] ToBytes(Type type, object? value) =>
        MemoryPackHelper.ToBytes(type, value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MemoryPackHelper.FromBytes<TValue>(bytes, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MemoryPackHelper.FromBytes(type, bytes, _options);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        MemoryPackHelper.Pack(value, stream, _options);

    public void Pack(Type type, object? value, Stream? stream) =>
        MemoryPackHelper.Pack(type, value, stream, _options);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MemoryPackHelper.ToStream(value, _options);

    public MemoryStream ToStream(Type type, object? value) =>
        MemoryPackHelper.ToStream(type, value, _options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MemoryPackHelper.FromStream<TValue>(stream, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MemoryPackHelper.FromStream(type, stream, _options);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await MemoryPackHelper.PackAsync(value, stream, _options, cancellationToken);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await MemoryPackHelper.PackAsync(type, value, stream, _options, cancellationToken);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await MemoryPackHelper.FromStreamAsync<TValue>(stream, _options, cancellationToken);

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await MemoryPackHelper.FromStreamAsync(type, stream, _options, cancellationToken);
}