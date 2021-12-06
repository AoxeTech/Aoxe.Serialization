namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static TValue? FromJson<TValue>(this string? str, Options? options = null) =>
        JilHelper.Deserialize<TValue>(str, options);

    public static object? FromJson(this string? str, Type type, Options? options = null) =>
        JilHelper.Deserialize(type, str, options);
}