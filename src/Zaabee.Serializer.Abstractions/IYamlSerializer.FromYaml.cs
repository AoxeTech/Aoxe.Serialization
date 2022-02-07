namespace Zaabee.Serializer.Abstractions;

public partial interface IYamlSerializer
{
    /// <summary>
    /// If the yaml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="yaml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromYaml<TValue>(string? yaml);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="yaml"></param>
    /// <returns></returns>
    object? FromYaml(Type type, string? yaml);
}