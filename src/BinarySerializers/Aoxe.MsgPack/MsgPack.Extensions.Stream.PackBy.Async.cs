namespace Aoxe.MsgPack;

public static partial class MsgPackExtensions
{
    public static ValueTask PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        CancellationToken cancellationToken = default
    ) => MsgPackHelper.PackAsync(value, stream, cancellationToken);

    public static ValueTask PackByAsync(
        this Stream? stream,
        Type type,
        object? value,
        PackerCompatibilityOptions packerCompatibilityOptions = PackerCompatibilityOptions.None,
        CancellationToken cancellationToken = default
    ) =>
        MsgPackHelper.PackAsync(type, value, stream, packerCompatibilityOptions, cancellationToken);
}
