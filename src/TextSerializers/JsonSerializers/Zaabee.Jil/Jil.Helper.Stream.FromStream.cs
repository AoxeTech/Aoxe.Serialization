namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = FromJson<TValue>(stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream, Options? options = null, Encoding? encoding = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = FromJson(type, stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}