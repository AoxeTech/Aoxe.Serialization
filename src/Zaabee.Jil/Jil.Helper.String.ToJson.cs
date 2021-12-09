namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static string ToJson<TValue>(TValue? value, Options? options = null) =>
        JilSerializer.ToJson(value, options ?? DefaultOptions);

    public static string ToJson(object? value, Options? options = null) =>
        JilSerializer.ToJson(value, options ?? DefaultOptions);
}