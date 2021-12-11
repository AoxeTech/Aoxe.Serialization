namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<TValue>(TValue? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        await JsonSerializer.SerializeAsync(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task PackAsync(Type type, object? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        await JsonSerializer.NonGeneric.SerializeAsync(type, stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task PackAsync(object? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        await JsonSerializer.NonGeneric.SerializeAsync(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}