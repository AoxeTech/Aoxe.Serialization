namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static async Task PackAsync<TValue>(TValue? value, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is not null)
            await JilSerializer.PackAsync(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
    }

    public static async Task PackAsync(object? value, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is not null)
            await JilSerializer.PackAsync(value, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
    }
}