namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(value, stream, options, encoding);

    public static Task PackToAsync(this object? value, Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.PackAsync(value, stream, options, encoding);
}