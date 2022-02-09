namespace Zaabee.MsgPack;

public class Serializer : IBytesSerializer, IStreamSerializerAsync
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

    public MemoryStream ToStream<TValue>(TValue? value) =>
        MsgPackHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        MsgPackHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MsgPackHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MsgPackHelper.FromStream(type, stream);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await MsgPackHelper.PackAsync(value, stream, cancellationToken);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await MsgPackHelper.PackAsync(type, value, stream, PackerCompatibilityOptions.None, cancellationToken);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : await MsgPackHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : await MsgPackHelper.FromStreamAsync(type, stream, cancellationToken);
}