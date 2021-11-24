namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static MemoryStream Pack<T>(T value, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        Pack(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static MemoryStream Pack(object obj, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        Pack(obj, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static MemoryStream Pack(Type type, object obj, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        Pack(type, obj, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver)
    {
        JsonSerializer.Serialize(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    public static void Pack(object obj, Stream stream, IJsonFormatterResolver resolver)
    {
        JsonSerializer.NonGeneric.Serialize(stream, obj, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    public static void Pack(Type type, object obj, Stream stream, IJsonFormatterResolver resolver)
    {
        JsonSerializer.NonGeneric.Serialize(type, stream, obj, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into an instance of a type specified by a generic type parameter.
    /// The Stream will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver)
    {
        var result = JsonSerializer.Deserialize<T>(stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver)
    {
        var result = JsonSerializer.NonGeneric.Deserialize(type, stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}