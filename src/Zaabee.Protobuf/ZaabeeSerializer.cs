namespace Zaabee.Protobuf;

public class ZaabeeSerializer : IBytesSerializer
{
    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromStream<TValue>(stream);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ProtobufHelper.ToStream(value);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromStream(type, stream);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes<TValue>(value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromBytes<TValue>(bytes!);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufHelper.ToBytes(value);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufHelper.FromBytes(type, bytes!);
}