namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static TValue? FromJson<TValue>(this string? json) =>
        SpanJsonHelper.FromJson<TValue>(json);

    public static object? FromJson(this string? json, Type type) =>
        SpanJsonHelper.FromJson(type, json);
}
