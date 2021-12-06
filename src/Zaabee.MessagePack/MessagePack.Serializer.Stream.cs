namespace Zaabee.MessagePack;

public static partial class MessagePackCSharpSerializer
{
    public static Stream Pack<TValue>(TValue value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        Pack(value, ms, options, cancellationToken);
        return ms;
    }

    public static void Pack<TValue>(TValue value, Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        MessagePackSerializer.Serialize(stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static Stream Pack(Type type, object? value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, options, cancellationToken);
        return ms;
    }

    public static void Pack(Type type, object? value, Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        MessagePackSerializer.Serialize(type, stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static TValue? Unpack<TValue>(Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var result = MessagePackSerializer.Deserialize<TValue>(stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static object? Unpack(Type type, Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var result = MessagePackSerializer.Deserialize(type, stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}