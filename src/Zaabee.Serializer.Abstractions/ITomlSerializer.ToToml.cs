namespace Zaabee.Serializer.Abstractions;

public partial interface ITomlSerializer
{
}

public static partial class TomlSerializerExtension
{
    /// <summary>
    /// Serialize to toml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToToml<TValue>(this ITomlSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to toml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToToml(this ITomlSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);
}