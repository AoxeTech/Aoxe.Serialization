namespace Aoxe.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes, NetJSONSettings? settings = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromJson<TValue>(bytes.GetStringByUtf8(), settings);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[]? bytes, NetJSONSettings? settings = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromJson(type, bytes.GetStringByUtf8(), settings);
}
