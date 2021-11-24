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
    public static async Task<MemoryStream> PackAsync<T>(T value, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync(object obj, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        await PackAsync(obj, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync(Type type, object obj, IJsonFormatterResolver resolver)
    {
        var ms = new MemoryStream();
        await PackAsync(type, obj, ms, resolver);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<T>(T value, Stream stream, IJsonFormatterResolver resolver)
    {
        await JsonSerializer.SerializeAsync(stream, value, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task PackAsync(Type type, object obj, Stream stream, IJsonFormatterResolver resolver)
    {
        await JsonSerializer.NonGeneric.SerializeAsync(type, stream, obj, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task PackAsync(object obj, Stream stream, IJsonFormatterResolver resolver)
    {
        await JsonSerializer.NonGeneric.SerializeAsync(stream, obj, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into an instance of a type
    /// specified by a generic type parameter.
    /// The Stream will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> UnpackAsync<T>(Stream stream, IJsonFormatterResolver resolver)
    {
        var result = await JsonSerializer.DeserializeAsync<T>(stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Asynchronously reads the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static async Task<object> UnpackAsync(Type type, Stream stream, IJsonFormatterResolver resolver)
    {
        var result = await JsonSerializer.NonGeneric.DeserializeAsync(type, stream, resolver);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}