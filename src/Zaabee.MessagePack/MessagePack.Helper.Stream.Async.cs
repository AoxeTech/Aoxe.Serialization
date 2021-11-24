namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static Task<MemoryStream> PackAsync<T>(T t, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        t is null
            ? Task.FromResult(new MemoryStream())
            : MessagePackCSharpSerializer.PackAsync(t, options ?? DefaultOptions, cancellationToken);

    public static Task PackAsync<T>(T t, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        t is null || stream is null
            ? Task.CompletedTask
            : MessagePackCSharpSerializer.PackAsync(t, stream, options ?? DefaultOptions, cancellationToken);

    public static Task<MemoryStream> PackAsync(Type type, object obj, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackCSharpSerializer.PackAsync(type, obj, options ?? DefaultOptions, cancellationToken);

    public static Task PackAsync(Type type, object obj, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackCSharpSerializer.PackAsync(type, obj, stream, options ?? DefaultOptions, cancellationToken);

    public static ValueTask<T> UnpackAsync<T>(Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? new ValueTask<T>((T)typeof(T).GetDefaultValue())
            : MessagePackCSharpSerializer.UnpackAsync<T>(stream, options ?? DefaultOptions, cancellationToken);

    public static ValueTask<object> UnpackAsync(Type type, Stream stream,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        MessagePackCSharpSerializer.UnpackAsync(type, stream, options ?? DefaultOptions, cancellationToken);
}