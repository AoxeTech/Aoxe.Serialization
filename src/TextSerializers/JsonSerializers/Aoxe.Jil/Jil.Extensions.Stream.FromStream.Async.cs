namespace Aoxe.Jil;

public static partial class JilExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        Options? options = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => JilHelper.FromStreamAsync<TValue>(stream, options, encoding, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        Options? options = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    ) => JilHelper.FromStreamAsync(type, stream, options, encoding, cancellationToken);
}
