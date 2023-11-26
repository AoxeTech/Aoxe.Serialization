namespace Zaabee.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToJson<TValue>(TValue? value, NetJSONSettings? settings = null) =>
        NetJSON.NetJSON.Serialize(value, settings ?? NetJSONSettings.CurrentSettings);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static string ToJson(object? value, NetJSONSettings? settings = null) =>
        value is null
            ? "null"
            : NetJSON.NetJSON.SerializeObject(value, settings ?? NetJSONSettings.CurrentSettings);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static string ToJson(Type type, object? value, NetJSONSettings? settings = null) =>
        NetJSON.NetJSON.Serialize(type, value, settings ?? NetJSONSettings.CurrentSettings);
}
