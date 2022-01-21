namespace Zaabee.Serializer.Abstractions;

public interface IYamlSerializer : ITextSerializer
{
    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToYaml<TValue>(TValue? value);

    /// <summary>
    /// If the yaml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="yaml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromYaml<TValue>(string? yaml);

    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToYaml(Type type, object? value);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="yaml"></param>
    /// <returns></returns>
    object? FromYaml(Type type, string? yaml);
}