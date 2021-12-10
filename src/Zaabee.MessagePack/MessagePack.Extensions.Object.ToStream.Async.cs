namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.ToStreamAsync(value, options, cancellationToken);

    public static Task<MemoryStream> ToStreamAsync(this object? value, Type type,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.ToStreamAsync(type, value, options, cancellationToken);
}