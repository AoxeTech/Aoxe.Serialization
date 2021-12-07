namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue value, IJsonFormatterResolver? resolver)
    {
        var ms = new MemoryStream();
        Pack(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static Stream Pack(object? value, IJsonFormatterResolver? resolver)
    {
        var ms = new MemoryStream();
        Pack(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static Stream Pack(Type type, object? value, IJsonFormatterResolver? resolver)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue value, Stream? stream, IJsonFormatterResolver? resolver)
    {
        JsonSerializer.Serialize(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    public static void Pack(object? value, Stream? stream, IJsonFormatterResolver? resolver)
    {
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
    public static void Pack(Type type, object? value, Stream? stream, IJsonFormatterResolver? resolver)
    {
        JsonSerializer.NonGeneric.Serialize(type, stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into an instance of a type specified by a generic type parameter.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream, IJsonFormatterResolver? resolver)
    {
        var result = JsonSerializer.Deserialize<TValue>(stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream, IJsonFormatterResolver? resolver)
    {
        var result = JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}