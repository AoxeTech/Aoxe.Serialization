namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.FromStreamAsync<TValue>(stream, options, encoding);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.FromStreamAsync(type, stream, options, encoding);
}