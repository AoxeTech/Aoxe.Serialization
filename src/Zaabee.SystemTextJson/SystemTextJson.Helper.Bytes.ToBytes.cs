namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Convert the provided value into a <see cref="System.Byte"/> array.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, JsonSerializerOptions? options = null) =>
        JsonSerializer.SerializeToUtf8Bytes(value, options);

    /// <summary>
    /// Convert the provided value into a <see cref="System.Byte"/> array.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value, JsonSerializerOptions? options = null) =>
        JsonSerializer.SerializeToUtf8Bytes(value, type, options);
}