namespace Zaabee.ZeroFormatter;

public class Serializer : IBytesSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroFormatterHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : ZeroFormatterHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : ZeroFormatterHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : ZeroFormatterHelper.FromBytes(type, bytes);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : ZeroFormatterHelper.ToStream(value);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : ZeroFormatterHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : ZeroFormatterHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : ZeroFormatterHelper.FromStream(type, stream);
}