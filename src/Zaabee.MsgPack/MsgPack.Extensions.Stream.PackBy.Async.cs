namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(value, stream, cancellationToken);

    public static Task PackByAsync(this Stream? stream, Type type, object? value,
        PackerCompatibilityOptions packerCompatibilityOptions = PackerCompatibilityOptions.None,
        CancellationToken cancellationToken = default) =>
        MsgPackHelper.PackAsync(type, value, stream, packerCompatibilityOptions, cancellationToken);
}