namespace Zaabee.ZeroFormatter;

public class Serializer : IBytesSerializer
{
    public byte[] SerializeToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroFormatterHelper.ToBytes(value);

    public byte[] SerializeToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroFormatterHelper.ToBytes(type, value);

    public TValue? DeserializeFromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroFormatterHelper.FromBytes<TValue>(bytes!);

    public object? DeserializeFromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : ZeroFormatterHelper.FromBytes(type, bytes!);

    public Stream SerializeToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ZeroFormatterHelper.ToStream(value);

    public Stream SerializeToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ZeroFormatterHelper.ToStream(type, value);

    public TValue? DeserializeFromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroFormatterHelper.FromStream<TValue>(stream);

    public object? DeserializeFromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroFormatterHelper.FromStream(type, stream);
}