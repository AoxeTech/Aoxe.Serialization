namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(TValue? value, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        await JilSerializer.ToStreamAsync(value, encoding ?? DefaultEncoding, options ?? DefaultOptions,
            cancellationToken);

    public static async Task<MemoryStream> ToStreamAsync(object? value, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        await JilSerializer.ToStreamAsync(value, encoding ?? DefaultEncoding, options ?? DefaultOptions,
            cancellationToken);
}