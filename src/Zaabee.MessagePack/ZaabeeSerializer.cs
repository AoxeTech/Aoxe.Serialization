namespace Zaabee.MessagePack;

public class ZaabeeSerializer : IBytesSerializer
{
    private readonly MessagePackSerializerOptions? _options;

    public ZaabeeSerializer(MessagePackSerializerOptions? options = null) =>
        _options = options;

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackCSharpSerializer.Serialize(value, _options);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackCSharpSerializer.Serialize(type, value, _options);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Deserialize<TValue>(bytes, _options);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Deserialize(type, bytes, _options);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : MessagePackCSharpSerializer.Pack(value, _options);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : MessagePackCSharpSerializer.Pack(type, value, _options);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Unpack<TValue>(stream, _options);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Unpack(type, stream, _options);
}