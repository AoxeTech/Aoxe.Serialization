namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static Stream Pack<TValue>(TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Stream.Null
            : MessagePackCSharpSerializer.Pack(value, options ?? DefaultOptions, cancellationToken);

    public static void Pack<TValue>(TValue value, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (value is null || stream is null) return;
        MessagePackCSharpSerializer.Pack(value, stream, options ?? DefaultOptions, cancellationToken);
    }

    public static Stream Pack(Type type, object? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Stream.Null
            : MessagePackCSharpSerializer.Pack(type, value, options ?? DefaultOptions, cancellationToken);

    public static void Pack(Type type, object? value, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (value is null || stream is null) return;
        MessagePackCSharpSerializer.Pack(type, value, stream, options ?? DefaultOptions, cancellationToken);
    }

    public static TValue? Unpack<TValue>(Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Unpack<TValue>(stream, options ?? DefaultOptions, cancellationToken);

    public static object? Unpack(Type type, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? default
            : MessagePackCSharpSerializer.Unpack(type, stream, options ?? DefaultOptions, cancellationToken);
}