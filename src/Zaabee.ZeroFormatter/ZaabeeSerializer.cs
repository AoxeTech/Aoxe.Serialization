namespace Zaabee.ZeroFormatter;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroSerializer.Serialize(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroSerializer.Serialize(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Deserialize<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Deserialize(type, bytes!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ZeroSerializer.Pack(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ZeroSerializer.Pack(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Unpack<TValue>(stream);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Unpack(type, stream);
}