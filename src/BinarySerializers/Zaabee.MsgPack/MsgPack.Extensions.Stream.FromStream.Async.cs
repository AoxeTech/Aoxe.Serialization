namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(this Stream? stream,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(this Stream? stream, Type type,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.FromStreamAsync(type, stream, cancellationToken);
}