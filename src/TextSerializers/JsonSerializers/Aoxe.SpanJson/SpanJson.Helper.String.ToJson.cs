namespace Aoxe.SpanJson;

public static partial class SpanJsonHelper
{
    public static string ToJson<TValue>(TValue? value) =>
        value is null ? string.Empty : ToBytes(value).GetStringByUtf8();

    public static string ToJson(object? value) =>
        value is null ? string.Empty : ToBytes(value).GetStringByUtf8();
}
