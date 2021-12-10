namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Parse the UTF-8 encoded text representing a single JSON value into a <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(ReadOnlySpan<byte> bytes, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize<TValue>(bytes, options);

    /// <summary>
    /// Parse the UTF-8 encoded text representing a single JSON value into a <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, ReadOnlySpan<byte> bytes, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize(bytes, type, options);
}