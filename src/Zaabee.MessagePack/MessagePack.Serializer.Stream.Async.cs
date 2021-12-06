namespace Zaabee.MessagePack;

public static partial class MessagePackCSharpSerializer
{
    public static async Task<MemoryStream> PackAsync<TValue>(TValue value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, options, cancellationToken);
        return ms;
    }

    public static async Task PackAsync<TValue>(TValue value, Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        await MessagePackSerializer.SerializeAsync(stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task<MemoryStream> PackAsync(Type type, object? value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(type, value, ms, options, cancellationToken);
        return ms;
    }

    public static async Task PackAsync(Type type, object? value, Stream? stream,
        MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        await MessagePackSerializer.SerializeAsync(type, stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask<TValue> UnpackAsync<TValue>(Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default)
    {
        var result = await MessagePackSerializer.DeserializeAsync<TValue>(stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static async ValueTask<object> UnpackAsync(Type type, Stream? stream,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default)
    {
        var result = await MessagePackSerializer.DeserializeAsync(type, stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}