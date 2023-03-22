namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Convert the provided value into a <see cref="System.String"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToJson<TValue>(TValue? value, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(value, options);

    /// <summary>
    /// Convert the provided value into a <see cref="System.String"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string ToJson(Type type, object? value, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(value, type, options);
}