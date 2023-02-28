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
    public static void Pack<TValue>(TValue? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        JsonSerializer.Serialize(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    public static void Pack(object? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        JsonSerializer.NonGeneric.Serialize(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    public static void Pack(Type type, object? value, Stream? stream, IJsonFormatterResolver? resolver = null)
    {
        if (stream is null) return;
        JsonSerializer.NonGeneric.Serialize(type, stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}