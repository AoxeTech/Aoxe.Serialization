namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static async Task<MemoryStream> PackAsync<TValue>(TValue? value, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        await JilSerializer.PackAsync(value, encoding ?? DefaultEncoding, options ?? DefaultOptions, cancellationToken);

    public static async Task<MemoryStream> PackAsync(object? value, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        await JilSerializer.PackAsync(value, encoding ?? DefaultEncoding, options ?? DefaultOptions, cancellationToken);

    public static async Task PackAsync<TValue>(TValue? value, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is not null)
            await JilSerializer.PackAsync(value, stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
    }

    public static async Task PackAsync(object? value, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is not null)
            await JilSerializer.PackAsync(value, stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
    }

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.UnpackAsync<TValue>(stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);

    public static async Task<object?> UnpackAsync(Type type, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.UnpackAsync(type, stream!, encoding ?? DefaultEncoding, options ?? DefaultOptions,
                cancellationToken);
}