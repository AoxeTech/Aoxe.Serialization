namespace Zaabee.Protobuf;

public sealed class Serializer : IBytesSerializer
{
    public MemoryStream ToStream<TValue>(TValue? value) => ProtobufHelper.ToStream(value);

    public void Pack<TValue>(TValue? value, Stream? stream) => ProtobufHelper.Pack(value, stream);

    public void Pack(Type type, object? value, Stream? stream) =>
        ProtobufHelper.Pack(value, stream);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : ProtobufHelper.FromStream<TValue>(stream);

    public MemoryStream ToStream(Type type, object? value) => ProtobufHelper.ToStream(value);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : ProtobufHelper.FromStream(type, stream);

    public byte[] ToBytes<TValue>(TValue? value) => ProtobufHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0 ? default : ProtobufHelper.FromBytes<TValue>(bytes);

    public byte[] ToBytes(Type type, object? value) => ProtobufHelper.ToBytes(value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0 ? default : ProtobufHelper.FromBytes(type, bytes);
}
