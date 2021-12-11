namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.Serialize(value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.NonGeneric.Serialize(type, value, resolver);

    /// <summary>
    /// Serialize to binary with specified resolver.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static byte[] ToBytes(object? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.NonGeneric.Serialize(value, resolver);
}