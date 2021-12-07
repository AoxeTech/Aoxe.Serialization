namespace Zaabee.Protobuf;

public class ZaabeeSerializer : IBytesSerializer
{
    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ProtobufSerializer.Pack(value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Unpack<TValue>(stream);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ProtobufSerializer.Pack(value);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Unpack(type, stream);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufSerializer.Serialize<TValue>(value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Deserialize<TValue>(bytes!);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ProtobufSerializer.Serialize(value);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ProtobufSerializer.Deserialize(type, bytes!);
}