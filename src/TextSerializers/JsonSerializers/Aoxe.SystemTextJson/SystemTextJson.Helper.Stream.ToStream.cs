namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(
        TValue? value,
        JsonSerializerOptions? options = null
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, options);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(
        Type type,
        object? value,
        JsonSerializerOptions? options = null
    )
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, options);
        return ms;
    }
}
