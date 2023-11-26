namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static string ToJson<TValue>(this TValue? value, Options? options = null) =>
        JilHelper.ToJson(value, options);

    public static string ToJson(this object? value, Options? options = null) =>
        JilHelper.ToJson(value, options);
}
