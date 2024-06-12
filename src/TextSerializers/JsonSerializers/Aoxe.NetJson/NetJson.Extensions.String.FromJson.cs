namespace Aoxe.NetJson;

public static partial class NetJsonExtensions
{
    public static TValue? FromJson<TValue>(this string? json, NetJSONSettings? settings = null) =>
        NetJsonHelper.FromJson<TValue>(json, settings);

    public static object? FromJson(
        this string? json,
        Type type,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.FromJson(type, json, settings);
}
