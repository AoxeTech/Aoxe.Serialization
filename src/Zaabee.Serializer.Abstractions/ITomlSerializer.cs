namespace Zaabee.Serializer.Abstractions;

public interface ITomlSerializer : ITextSerializer
{
}

public static class TomlSerializerExtension
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

    /// <summary>
    /// If the toml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="toml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromToml<TValue>(this ITomlSerializer serializer, string? toml) =>
        serializer.FromText<TValue>(toml);

    /// <summary>
    /// If the toml is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="toml"></param>
    /// <returns></returns>
    public static object? FromToml(this ITomlSerializer serializer, Type type, string? toml) =>
        serializer.FromText(type, toml);
}