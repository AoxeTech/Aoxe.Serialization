namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.FromStreamAsync<TValue>(stream, encoding ?? DefaultEncoding,
                options ?? DefaultOptions, cancellationToken);

    public static async Task<object?> FromStreamAsync(Type type, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.FromStreamAsync(type, stream, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
}