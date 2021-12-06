namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(value, stream, options, encoding);

    public static Task PackByAsync(this Stream? stream, object? value, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(value, stream, options, encoding);

    public static Task<TValue?> UnpackAsync<TValue>(this Stream? stream, Options? options = null, Encoding? encoding = null) =>
        JilHelper.UnpackAsync<TValue>(stream, options, encoding);

    public static Task<object?> UnpackAsync(this Stream? stream, Type type, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.UnpackAsync(type, stream, options, encoding);
}