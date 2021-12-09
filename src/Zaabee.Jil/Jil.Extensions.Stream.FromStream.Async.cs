namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static async Task<TValue?> FromStreamAsync<TValue>(this Stream? stream, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.FromStreamAsync<TValue>(stream, options, encoding);

    public static async Task<object?> FromStreamAsync(this Stream? stream, Type type, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.FromStreamAsync(type, stream, options, encoding);
}