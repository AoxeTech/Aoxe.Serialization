namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static async Task<byte[]> ToBytesAsync<TValue>(TValue? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var ms = new MemoryStream();
        await MessagePackSerializer.SerializeAsync(ms, value, options, cancellationToken);
        return await ms.ReadToEndAsync(cancellationToken);
    }
}