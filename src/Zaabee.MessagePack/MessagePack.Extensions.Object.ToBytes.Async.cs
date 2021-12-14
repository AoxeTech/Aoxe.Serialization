namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static async Task<byte[]> ToBytesAsync<TValue>(this TValue? value,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        await MessagePackHelper.ToBytesAsync(value, options, cancellationToken);
}