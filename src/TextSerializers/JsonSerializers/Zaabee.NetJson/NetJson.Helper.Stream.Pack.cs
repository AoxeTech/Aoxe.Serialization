namespace Zaabee.NetJson;

public static partial class NetJsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        ToJson(value, settings).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    public static void Pack(object? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        ToJson(value, settings).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    public static void Pack(Type type, object? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        ToJson(type, value, settings).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}