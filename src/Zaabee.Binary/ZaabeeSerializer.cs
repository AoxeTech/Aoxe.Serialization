namespace Zaabee.Binary;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public class ZaabeeSerializer : IBytesSerializer
{
    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : BinarySerializer.ToStream(value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.FromStream<TValue>(stream!);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : BinarySerializer.ToStream(value);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.FromStream(stream!);

    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.ToBytes(value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinarySerializer.FromBytes<TValue>(bytes!);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.ToBytes(value);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinarySerializer.FromBytes(bytes!);
}