namespace Zaabee.MessagePack;

public class Serializer : IBytesSerializer
{
    private readonly MessagePackSerializerOptions? _options;

    public Serializer(MessagePackSerializerOptions? options = null) =>
        _options = options;

    public byte[] ToBytes<TValue>(TValue? value) =>
        MessagePackHelper.ToBytes(value, _options);

    public byte[] ToBytes(Type type, object? value) =>
        MessagePackHelper.ToBytes(type, value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes<TValue>(bytes, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : MessagePackHelper.FromBytes(type, bytes, _options);

    public Stream ToStream<TValue>(TValue? value) =>
        MessagePackHelper.ToStream(value, _options);

    public Stream ToStream(Type type, object? value) =>
        MessagePackHelper.ToStream(type, value, _options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MessagePackHelper.FromStream<TValue>(stream, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : MessagePackHelper.FromStream(type, stream, _options);
}