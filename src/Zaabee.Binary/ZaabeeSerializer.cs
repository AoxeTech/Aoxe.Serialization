namespace Zaabee.Binary;

public class ZaabeeSerializer : IBytesSerializer
{
    public byte[] SerializeToBytes<T>(T? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.Serialize(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.Serialize(value);

    public T? DeserializeFromBytes<T>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? (T?)typeof(T).GetDefaultValue()
            : BinarySerializer.Deserialize<T>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : BinarySerializer.Deserialize(bytes!);

    public Stream SerializeToStream<T>(T? value) =>
        value is null
            ? new MemoryStream()
            : BinarySerializer.Pack(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? new MemoryStream()
            : BinarySerializer.Pack(value);

    public T? DeserializeFromStream<T>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? (T?)typeof(T).GetDefaultValue()
            : BinarySerializer.Unpack<T>(stream!);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : BinarySerializer.Unpack(stream!);
}