namespace Aoxe.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Serialize to binary with specified settings.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, NetJSONSettings? settings = null) =>
        ToJson(value, settings).GetUtf8Bytes();

    /// <summary>
    /// Serialize to binary with specified settings.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value, NetJSONSettings? settings = null) =>
        ToJson(type, value, settings).GetUtf8Bytes();

    /// <summary>
    /// Serialize to binary with specified settings.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static byte[] ToBytes(object? value, NetJSONSettings? settings = null) =>
        ToJson(value, settings).GetUtf8Bytes();
}
