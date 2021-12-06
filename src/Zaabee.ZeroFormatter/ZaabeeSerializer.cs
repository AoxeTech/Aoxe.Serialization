namespace Zaabee.ZeroFormatter;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue value) =>
        ZeroSerializer.Serialize(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        ZeroSerializer.Serialize(type, value);

    public TValue DeserializeFromBytes<TValue>(byte[] bytes) =>
        ZeroSerializer.Deserialize<TValue>(bytes);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        ZeroSerializer.Deserialize(type, bytes);

    public Stream? SerializeToStream<TValue>(TValue value) =>
        ZeroSerializer.Pack(value);

    public Stream? SerializeToStream(Type type, object? value) =>
        ZeroSerializer.Pack(type, value);

    public TValue DeserializeFromStream<TValue>(Stream? stream) =>
        ZeroSerializer.Unpack<TValue>(stream);

    public object DeserializeFromStream(Type type, Stream? stream) =>
        ZeroSerializer.Unpack(type, stream);
}