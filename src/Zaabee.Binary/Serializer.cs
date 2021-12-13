namespace Zaabee.Binary;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public class Serializer : IBytesSerializer
{
    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : BinaryHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinaryHelper.FromStream<TValue>(stream!);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : BinaryHelper.ToStream(value);

    public object? FromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinaryHelper.FromStream(stream!);

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinaryHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinaryHelper.FromBytes<TValue>(bytes!);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinaryHelper.ToBytes(value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : BinaryHelper.FromBytes(bytes!);
}