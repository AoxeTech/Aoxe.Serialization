namespace Zaabee.Serializer.Abstractions;

public partial interface ITomlSerializer : ITextSerializer
{
}

public static partial class TomlSerializerExtension
{
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