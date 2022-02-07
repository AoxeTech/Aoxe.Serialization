namespace Zaabee.Serializer.Abstractions;

public partial interface IYamlSerializer : ITextSerializer
{
    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToYaml<TValue>(TValue? value);

    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToYaml(Type type, object? value);
}