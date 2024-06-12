namespace Aoxe.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value, NetJSONSettings? settings = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, settings);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(object? value, NetJSONSettings? settings = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, settings);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value, NetJSONSettings? settings = null)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, settings);
        return ms;
    }
}
