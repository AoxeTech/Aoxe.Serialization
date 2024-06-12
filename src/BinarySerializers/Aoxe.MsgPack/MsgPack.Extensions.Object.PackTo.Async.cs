namespace Aoxe.MsgPack;

public static partial class MsgPackExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    ) => MsgPackHelper.PackAsync(value, stream, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        PackerCompatibilityOptions packerCompatibilityOptions = PackerCompatibilityOptions.None,
        CancellationToken cancellationToken = default
    ) =>
        MsgPackHelper.PackAsync(type, value, stream, packerCompatibilityOptions, cancellationToken);
}
