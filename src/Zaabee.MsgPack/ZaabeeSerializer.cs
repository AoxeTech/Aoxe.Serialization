namespace Zaabee.MsgPack;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        MsgPackSerializer.Serialize(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        MsgPackSerializer.Serialize(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        MsgPackSerializer.Deserialize<TValue>(bytes);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        MsgPackSerializer.Deserialize(type, bytes);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        MsgPackSerializer.Pack(value);

    public Stream SerializeToStream(Type type, object? value) =>
        MsgPackSerializer.Pack(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        MsgPackSerializer.Unpack<TValue>(stream);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        MsgPackSerializer.Unpack(type, stream);
}