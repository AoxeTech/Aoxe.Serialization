namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, options, encoding);

    public static async Task<MemoryStream> ToStreamAsync(this object? value, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, options, encoding);

    public static async Task PackToAsync<TValue>(this TValue? value, Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, stream, options, encoding);

    public static async Task PackToAsync(this object? value, Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, stream, options, encoding);
}