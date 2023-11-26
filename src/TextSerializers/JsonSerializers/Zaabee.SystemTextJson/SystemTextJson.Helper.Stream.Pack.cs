namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream,
        JsonSerializerOptions? options = null
    )
    {
        if (stream is null)
            return;
        JsonSerializer.Serialize(stream, value, options);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    public static void Pack(
        Type type,
        object? value,
        Stream? stream,
        JsonSerializerOptions? options = null
    )
    {
        if (stream is null)
            return;
        JsonSerializer.Serialize(stream, value, type, options);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
