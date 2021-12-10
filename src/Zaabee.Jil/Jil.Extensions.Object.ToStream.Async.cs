namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.ToStreamAsync(value, options, encoding);

    public static Task<MemoryStream> ToStreamAsync(this object? value, Options? options = null,
        Encoding? encoding = null) =>
        JilHelper.ToStreamAsync(value, options, encoding);
}