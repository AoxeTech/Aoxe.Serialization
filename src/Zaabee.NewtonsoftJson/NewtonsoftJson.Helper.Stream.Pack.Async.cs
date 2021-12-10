namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<TValue>(TValue? value, Stream? stream, JsonSerializerSettings? settings,
        Encoding? encoding = null)
    {
        if (stream.IsNullOrEmpty()) return;
        await ToBytes(value, settings, encoding).WriteToAsync(stream!, CancellationToken.None);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task PackAsync(Type type, object? value, Stream? stream, JsonSerializerSettings? settings,
        Encoding? encoding = null)
    {
        if (stream.IsNullOrEmpty()) return;
        await ToBytes(type, value, settings, encoding).WriteToAsync(stream!, CancellationToken.None);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}