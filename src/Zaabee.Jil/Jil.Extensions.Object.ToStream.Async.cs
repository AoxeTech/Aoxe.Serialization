namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value, Options? options = null, Encoding? encoding = null) =>
        await JilHelper.ToStreamAsync(value, options, encoding);

    public static async Task<MemoryStream> ToStreamAsync(this object? value, Options? options = null, Encoding? encoding = null) =>
        await JilHelper.ToStreamAsync(value, options, encoding);
}