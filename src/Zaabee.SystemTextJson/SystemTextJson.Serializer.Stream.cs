namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonSerializer
{
    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue? value, JsonSerializerOptions? options)
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
    public static Stream Pack(Type type, object? value, JsonSerializerOptions? options)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, options);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream, JsonSerializerOptions? options)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
        stream.Write(bytes, 0, bytes.Length);
        if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Convert the provided value to UTF-8 encoded JSON text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    public static void Pack(Type type, object? value, Stream? stream, JsonSerializerOptions? options)
    {
        JsonSerializer.SerializeToUtf8Bytes(value, type, options).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into an instance of a type specified by a generic type parameter.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream, JsonSerializerOptions? options)
    {
        var result = Deserialize<TValue>(stream.ReadToEnd(), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// The Stream? will be try seek to beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream, JsonSerializerOptions? options)
    {
        var result = Deserialize(type, stream.ReadToEnd(), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}