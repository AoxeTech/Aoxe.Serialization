namespace Zaabee.Protobuf;

public class Serializer : IBytesSerializer
{
    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromStream<TValue>(stream);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public object? FromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromStream(type, stream);

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes<TValue>(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromBytes<TValue>(bytes!);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes(value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromBytes(type, bytes!);
}