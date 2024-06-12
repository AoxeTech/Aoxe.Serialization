namespace Aoxe.SpanJson;

public static partial class SpanJsonExtensions
{
    public static string ToJson<TValue>(this TValue? value) => SpanJsonHelper.ToJson(value);

    public static string ToJson(this object? value) => SpanJsonHelper.ToJson(value);
}
