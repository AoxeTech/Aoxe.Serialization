namespace Zaabee.Protobuf;

public class Serializer : IBytesSerializer
{
    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : ProtobufHelper.FromStream<TValue>(stream);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : ProtobufHelper.FromStream(type, stream);

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : ProtobufHelper.FromBytes<TValue>(bytes);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes(value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : ProtobufHelper.FromBytes(type, bytes);
}