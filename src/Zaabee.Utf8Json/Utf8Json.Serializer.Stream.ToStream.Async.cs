namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<MemoryStream> ToStreamAsync<TValue>(TValue? value, IJsonFormatterResolver? resolver = null)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> ToStreamAsync(object? value, IJsonFormatterResolver? resolver = null)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> ToStreamAsync(Type type, object? value, IJsonFormatterResolver? resolver = null)
    {
        var ms = new MemoryStream();
        await PackAsync(type, value, ms, resolver);
        return ms;
    }
}