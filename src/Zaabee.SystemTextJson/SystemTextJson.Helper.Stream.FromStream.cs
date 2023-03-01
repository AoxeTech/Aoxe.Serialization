namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into an instance of a type specified by a generic type parameter.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream, JsonSerializerOptions? options = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = JsonSerializer.Deserialize<TValue>(stream, options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream, JsonSerializerOptions? options = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = JsonSerializer.Deserialize(stream, type, options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}