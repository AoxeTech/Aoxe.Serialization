namespace Aoxe.SpanJson;

public static partial class SpanJsonHelper
{
    public static TValue? FromJson<TValue>(string? json) =>
        string.IsNullOrWhiteSpace(json) ? default : FromBytes<TValue>(json.GetUtf8Bytes());

    public static object? FromJson(Type type, string? json) =>
        string.IsNullOrWhiteSpace(json) ? default : FromBytes(type, json.GetUtf8Bytes());
}
