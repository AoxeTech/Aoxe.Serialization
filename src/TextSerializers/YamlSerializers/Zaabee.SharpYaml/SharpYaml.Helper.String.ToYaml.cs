namespace Zaabee.SharpYaml;

public static partial class SharpYamlHelper
{
    /// <summary>
    /// Serialize the value to yaml string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToYaml<TValue>(TValue? value) =>
        new global::SharpYaml.Serialization.Serializer().Serialize(value, typeof(TValue));

    /// <summary>
    /// Serialize the value to yaml string.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToYaml(Type type, object? value) =>
        new global::SharpYaml.Serialization.Serializer().Serialize(value, type);
}
