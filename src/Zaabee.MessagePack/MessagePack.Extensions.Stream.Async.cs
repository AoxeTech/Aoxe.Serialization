namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static Task PackByAsync<T>(this Stream stream, T t, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(t, stream, options, cancellationToken);

    public static Task PackByAsync(this Stream stream, Type type, object obj,
        MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, obj, stream, options, cancellationToken);

    public static ValueTask<T> UnpackAsync<T>(this Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.UnpackAsync<T>(stream, options, cancellationToken);

    public static ValueTask<object> UnpackAsync(this Stream stream, Type type,
        MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.UnpackAsync(type, stream, options, cancellationToken);
}