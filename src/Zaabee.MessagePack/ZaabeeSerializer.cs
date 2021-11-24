namespace Zaabee.MessagePack;

public class ZaabeeSerializer : IBytesSerializer
{
    private readonly MessagePackSerializerOptions _options;

    public ZaabeeSerializer(MessagePackSerializerOptions options = null) =>
        _options = options;

    public byte[] SerializeToBytes<T>(T t) =>
        MessagePackCSharpSerializer.Serialize(t, _options);

    public byte[] SerializeToBytes(Type type, object obj) =>
        MessagePackCSharpSerializer.Serialize(type, obj, _options);

    public T DeserializeFromBytes<T>(byte[] bytes) =>
        MessagePackCSharpSerializer.Deserialize<T>(bytes, _options);

    public object DeserializeFromBytes(Type type, byte[] bytes) =>
        MessagePackCSharpSerializer.Deserialize(type, bytes, _options);

    public Stream SerializeToStream<T>(T t) =>
        MessagePackCSharpSerializer.Pack(t, _options);

    public Stream SerializeToStream(Type type, object obj) =>
        MessagePackCSharpSerializer.Pack(type, obj, _options);

    public T DeserializeFromStream<T>(Stream stream) =>
        MessagePackCSharpSerializer.Unpack<T>(stream, _options);

    public object DeserializeFromStream(Type type, Stream stream) =>
        MessagePackCSharpSerializer.Unpack(type, stream, _options);
}