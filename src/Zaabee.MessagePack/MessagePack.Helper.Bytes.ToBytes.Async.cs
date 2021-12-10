namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static async Task<byte[]> ToBytesAsync<TValue>(TValue? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_0
        using var ms = new MemoryStream();
#else
        await using var ms = new MemoryStream();
#endif
        await MessagePackSerializer.SerializeAsync(ms, value, options, cancellationToken);
        return await ms.ReadToEndAsync(cancellationToken);
    }
}