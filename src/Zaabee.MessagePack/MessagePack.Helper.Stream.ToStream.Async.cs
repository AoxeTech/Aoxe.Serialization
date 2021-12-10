namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(TValue? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, options, cancellationToken);
        return ms;
    }

    public static async Task<MemoryStream> ToStreamAsync(Type type, object? value,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(type, value, ms, options, cancellationToken);
        return ms;
    }
}