namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static string ToJson<TValue>(this TValue? value, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToJson(value, settings);

    public static string ToJson(this object? value, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToJson(value, settings);

    public static string ToJson(this object? value, Type type, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToJson(type, value, settings);
}