namespace Aoxe.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(
        byte[]? bytes,
        IJsonFormatterResolver? resolver = null
    ) =>
        bytes is null || bytes.Length is 0
            ? default
            : JsonSerializer.Deserialize<TValue>(bytes, resolver);

    /// <summary>
    /// Deserialize bytes to object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object? FromBytes(
        Type type,
        byte[]? bytes,
        IJsonFormatterResolver? resolver = null
    ) =>
        bytes is null || bytes.Length is 0
            ? default
            : JsonSerializer.NonGeneric.Deserialize(type, bytes, resolver);
}
