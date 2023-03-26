namespace Zaabee.Serializer.Abstractions;

public partial interface IYamlSerializer
{
}

public static partial class YamlSerializerExtension
{
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