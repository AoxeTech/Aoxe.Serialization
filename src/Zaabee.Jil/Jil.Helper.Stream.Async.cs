namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static Task<MemoryStream> PackAsync<T>(T? t, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        JilSerializer.PackAsync(t, options ?? DefaultOptions, encoding ?? DefaultEncoding, cancellationToken);

    public static Task<MemoryStream> PackAsync(object? obj, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        JilSerializer.PackAsync(obj, options ?? DefaultOptions, encoding ?? DefaultEncoding, cancellationToken);

    public static Task PackAsync<T>(T? t, Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? Task.CompletedTask
            : JilSerializer.PackAsync(t, stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static Task PackAsync(object? obj, Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? Task.CompletedTask
            : JilSerializer.PackAsync(obj, stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static async Task<T?> UnpackAsync<T>(Stream? stream, Options? options = null, Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? (T?)typeof(T).GetDefaultValue()
            : await JilSerializer.UnpackAsync<T>(stream!, options ?? DefaultOptions, encoding ?? DefaultEncoding,
                cancellationToken);

    public static async Task<object?> UnpackAsync(Type type, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : await JilSerializer.UnpackAsync(type, stream!, options ?? DefaultOptions,
                encoding ?? DefaultEncoding, cancellationToken);
}