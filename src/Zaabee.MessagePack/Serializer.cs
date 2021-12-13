namespace Zaabee.MessagePack;

public class Serializer : IBytesSerializer
{
    private readonly MessagePackSerializerOptions? _options;

    public Serializer(MessagePackSerializerOptions? options = null) =>
        _options = options;

    public byte[] ToBytes<TValue>(TValue? value) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackHelper.ToBytes(value, _options);

    public byte[] ToBytes(Type type, object? value) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackHelper.ToBytes(type, value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MessagePackHelper.FromBytes<TValue>(bytes, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes.IsNullOrEmpty()
            ? default
            : MessagePackHelper.FromBytes(type, bytes, _options);

    public Stream ToStream<TValue>(TValue? value) =>
        value is null
            ? Stream.Null
            : MessagePackHelper.ToStream(value, _options);

    public Stream ToStream(Type type, object? value) =>
        value is null
            ? Stream.Null
            : MessagePackHelper.ToStream(type, value, _options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackHelper.FromStream<TValue>(stream, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackHelper.FromStream(type, stream, _options);
}