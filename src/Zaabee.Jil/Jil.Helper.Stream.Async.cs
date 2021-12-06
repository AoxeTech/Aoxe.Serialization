namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static Task<MemoryStream> PackAsync<TValue>(TValue? value, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        JilSerializer.PackAsync(value, options ?? DefaultOptions, encoding ?? DefaultEncoding, cancellationToken);

    public static Task<MemoryStream> PackAsync(object? value, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        JilSerializer.PackAsync(value, options ?? DefaultOptions, encoding ?? DefaultEncoding, cancellationToken);

    public static Task PackAsync<TValue>(TValue? value, Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream is null
            ? Task.CompletedTask
            : JilSerializer.PackAsync(value, stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static Task PackAsync(object? value, Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream is null
            ? Task.CompletedTask
            : JilSerializer.PackAsync(value, stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.UnpackAsync<TValue>(stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static async Task<object?> UnpackAsync(Type type, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream is null
            ? default
            : await JilSerializer.UnpackAsync(type, stream!, options ?? DefaultOptions,
                encoding ?? DefaultEncoding, cancellationToken);
}