namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static MemoryStream Pack<T>(T t, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        t is null
            ? new MemoryStream()
            : MessagePackCSharpSerializer.Pack(t, options ?? DefaultOptions, cancellationToken);

    public static void Pack<T>(T t, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        if (t is null || stream is null) return;
        MessagePackCSharpSerializer.Pack(t, stream, options ?? DefaultOptions, cancellationToken);
    }

    public static MemoryStream Pack(Type type, object obj, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        obj is null
            ? new MemoryStream()
            : MessagePackCSharpSerializer.Pack(type, obj, options ?? DefaultOptions, cancellationToken);

    public static void Pack(Type type, object obj, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        if (obj is null || stream is null) return;
        MessagePackCSharpSerializer.Pack(type, obj, stream, options ?? DefaultOptions, cancellationToken);
    }

    public static T Unpack<T>(Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? (T)typeof(T).GetDefaultValue()
            : MessagePackCSharpSerializer.Unpack<T>(stream, options ?? DefaultOptions, cancellationToken);

    public static object Unpack(Type type, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : MessagePackCSharpSerializer.Unpack(type, stream, options ?? DefaultOptions, cancellationToken);
}