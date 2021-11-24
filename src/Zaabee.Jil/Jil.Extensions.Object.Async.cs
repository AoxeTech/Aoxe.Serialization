namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Task<MemoryStream> ToStreamAsync<T>(this T? t, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(t, options, encoding);

    public static Task<MemoryStream> ToStreamAsync(this object? obj, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(obj, options, encoding);

    public static Task PackToAsync<T>(this T? t, Stream stream, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(t, stream, options, encoding);

    public static Task PackToAsync(this object? obj, Stream stream, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(obj, stream, options, encoding);
}