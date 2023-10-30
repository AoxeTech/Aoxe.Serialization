namespace Zaabee.NetJson;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask PackAsync<TValue>(TValue? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        await ToJson(value, settings).WriteToAsync(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync(object? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        await ToJson(value, settings).WriteToAsync(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync(Type type, object? value, Stream? stream, NetJSONSettings? settings = null)
    {
        if (stream is null) return;
        await ToJson(type, value, settings).WriteToAsync(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}