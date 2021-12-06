namespace Zaabee.Binary;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public class ZaabeeSerializer : IBytesSerializer
{
    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : BinarySerializer.Pack(value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.Unpack<TValue>(stream!);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : BinarySerializer.Pack(value);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.Unpack(stream!);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.Serialize(value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinarySerializer.Deserialize<TValue>(bytes!);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.Serialize(value);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinarySerializer.Deserialize(bytes!);
}