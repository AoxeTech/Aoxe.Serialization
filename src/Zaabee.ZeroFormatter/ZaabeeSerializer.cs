namespace Zaabee.ZeroFormatter;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<T>(T t) =>
        ZeroSerializer.Serialize(t);

    public byte[] SerializeToBytes(Type type, object obj) =>
        ZeroSerializer.Serialize(type, obj);

    public T DeserializeFromBytes<T>(byte[] bytes) =>
        ZeroSerializer.Deserialize<T>(bytes);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        ZeroSerializer.Deserialize(type, bytes);

    public Stream SerializeToStream<T>(T t) =>
        ZeroSerializer.Pack(t);

    public Stream SerializeToStream(Type type, object obj) =>
        ZeroSerializer.Pack(type, obj);

    public T DeserializeFromStream<T>(Stream stream) =>
        ZeroSerializer.Unpack<T>(stream);

    public object DeserializeFromStream(Type type, Stream stream) =>
        ZeroSerializer.Unpack(type, stream);
}