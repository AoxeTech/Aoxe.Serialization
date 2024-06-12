namespace Aoxe.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Deserialize the json to an instance of the <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(string? json, NetJSONSettings? settings = null) =>
        string.IsNullOrWhiteSpace(json) || json is "null"
            ? default
            : NetJSON
                .NetJSON
                .Deserialize<TValue>(json, settings ?? NetJSONSettings.CurrentSettings);

    /// <summary>
    /// Deserialize the json to an instance of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static object? FromJson(Type type, string? json, NetJSONSettings? settings = null) =>
        string.IsNullOrWhiteSpace(json) || json is "null"
            ? default
            : NetJSON.NetJSON.Deserialize(type, json, settings ?? NetJSONSettings.CurrentSettings);
}
