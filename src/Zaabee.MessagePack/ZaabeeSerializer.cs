namespace Zaabee.MessagePack;

public class ZaabeeSerializer : IBytesSerializer
{
    private readonly MessagePackSerializerOptions? _options;

    public ZaabeeSerializer(MessagePackSerializerOptions? options = null) =>
        _options = options;

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        MessagePackCSharpSerializer.Serialize(value, _options);

    public byte[] SerializeToBytes(Type type, object? value) =>
        MessagePackCSharpSerializer.Serialize(type, value, _options);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        MessagePackCSharpSerializer.Deserialize<TValue>(bytes, _options);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        MessagePackCSharpSerializer.Deserialize(type, bytes, _options);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        MessagePackCSharpSerializer.Pack(value, _options);

    public Stream SerializeToStream(Type type, object? value) =>
        MessagePackCSharpSerializer.Pack(type, value, _options);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        MessagePackCSharpSerializer.Unpack<TValue>(stream, _options);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        MessagePackCSharpSerializer.Unpack(type, stream, _options);
}