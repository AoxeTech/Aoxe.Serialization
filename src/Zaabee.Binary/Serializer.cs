namespace Zaabee.Binary;

[ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
public class Serializer : IBytesSerializer
{
    public MemoryStream ToStream<TValue>(TValue? value) =>
        BinaryHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : BinaryHelper.FromStream<TValue>(stream);

    public MemoryStream ToStream(Type type, object? value) =>
        BinaryHelper.ToStream(value);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : BinaryHelper.FromStream(stream);

    public byte[] ToBytes<TValue>(TValue? value) =>
        BinaryHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : BinaryHelper.FromBytes<TValue>(bytes);

    public byte[] ToBytes(Type type, object? value) =>
        BinaryHelper.ToBytes(value);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : BinaryHelper.FromBytes(bytes);
}