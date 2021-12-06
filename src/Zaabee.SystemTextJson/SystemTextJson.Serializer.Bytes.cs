namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonSerializer
{
    /// <summary>
    /// Convert the provided value into a <see cref="System.Byte"/> array.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue? value, JsonSerializerOptions? options) =>
        JsonSerializer.SerializeToUtf8Bytes(value, options);

    /// <summary>
    /// Convert the provided value into a <see cref="System.Byte"/> array.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object? value, JsonSerializerOptions? options) =>
        JsonSerializer.SerializeToUtf8Bytes(value, type, options);

    /// <summary>
    /// Parse the UTF-8 encoded text representing a single JSON value into a <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(ReadOnlySpan<byte> bytes, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize<TValue>(bytes, options);

    /// <summary>
    /// Parse the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, ReadOnlySpan<byte> bytes, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize(bytes, type, options);
}