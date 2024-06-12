namespace Aoxe.SharpYaml;

public static partial class SharpYamlHelper
{
    /// <summary>
    /// Deserialize the yaml string to an instance of the <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="yaml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromYaml<TValue>(string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : new global::SharpYaml.Serialization.Serializer().Deserialize<TValue>(yaml!);

    /// <summary>
    /// Deserialize the yaml string to an instance of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="yaml"></param>
    /// <returns></returns>
    public static object? FromYaml(Type type, string? yaml) =>
        string.IsNullOrWhiteSpace(yaml)
            ? default
            : new global::SharpYaml.Serialization.Serializer().Deserialize(yaml!, type);
}
