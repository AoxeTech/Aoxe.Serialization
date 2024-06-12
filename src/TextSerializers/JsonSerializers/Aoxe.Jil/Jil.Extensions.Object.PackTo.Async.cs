namespace Aoxe.Jil;

public static partial class JilExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        Options? options = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, options, encoding, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Stream? stream,
        Options? options = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => JilHelper.PackAsync(value, stream, options, encoding, cancellationToken);
}
