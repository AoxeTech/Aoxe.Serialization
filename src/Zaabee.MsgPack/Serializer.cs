namespace Zaabee.MsgPack;

public class Serializer : IBytesSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : MsgPackHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MsgPackHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MsgPackHelper.FromBytes(type, bytes);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : MsgPackHelper.ToStream(value);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : MsgPackHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MsgPackHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MsgPackHelper.FromStream(type, stream);
}