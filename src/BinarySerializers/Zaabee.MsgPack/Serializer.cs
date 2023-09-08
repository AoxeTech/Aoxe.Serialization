namespace Zaabee.MsgPack;

public sealed class Serializer : IBytesSerializer, IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        MsgPackHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        MsgPackHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MsgPackHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MsgPackHelper.FromBytes(type, bytes);

    public void Pack<TValue>(TValue? value, Stream? stream) =>
        MsgPackHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        MsgPackHelper.Pack(type, value, stream);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MsgPackHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        MsgPackHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MsgPackHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : MsgPackHelper.FromStream(type, stream);

    public Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(value, stream, cancellationToken);

    public Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(type, value, stream, PackerCompatibilityOptions.None, cancellationToken);

    public Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? Task.FromResult(default(TValue?))
            : MsgPackHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? Task.FromResult(default(object?))
            : MsgPackHelper.FromStreamAsync(type, stream, cancellationToken);
}