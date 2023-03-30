namespace Zaabee.Serializer.Abstractions;

public interface IYamlSerializer : ITextSerializer
{
}

public static class YamlSerializerExtension
{
    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToYaml<TValue>(this IYamlSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToYaml(this IYamlSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);

    /// <summary>
    /// If the yaml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="yaml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromYaml<TValue>(this IYamlSerializer serializer, string? yaml) =>
        serializer.FromText<TValue>(yaml);

    /// <summary>
    /// If the yaml is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="yaml"></param>
    /// <returns></returns>
    public static object? FromYaml(this IYamlSerializer serializer, Type type, string? yaml) =>
        serializer.FromText(type, yaml);
}