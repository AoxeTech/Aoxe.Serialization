namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static TValue? FromJson<TValue>(this string? json, Options? options = null) =>
        JilHelper.FromJson<TValue>(json, options);

    public static object? FromJson(this string? json, Type type, Options? options = null) =>
        JilHelper.FromJson(type, json, options);
}