namespace Zaabee.Protobuf;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue value) =>
        ProtobufSerializer.Serialize(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        ProtobufSerializer.Serialize(value);

    public TValue DeserializeFromBytes<TValue>(byte[] bytes) =>
        ProtobufSerializer.Deserialize<TValue>(bytes);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        ProtobufSerializer.Deserialize(type, bytes);

    public Stream? SerializeToStream<TValue>(TValue value) =>
        ProtobufSerializer.Pack(value);

    public Stream? SerializeToStream(Type type, object? value) =>
        ProtobufSerializer.Pack(value);

    public TValue DeserializeFromStream<TValue>(Stream? stream) =>
        ProtobufSerializer.Unpack<TValue>(stream);

    public object DeserializeFromStream(Type type, Stream? stream) =>
        ProtobufSerializer.Unpack(type, stream);
}