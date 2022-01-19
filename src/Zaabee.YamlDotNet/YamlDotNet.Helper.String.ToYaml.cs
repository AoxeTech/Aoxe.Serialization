namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    /// <summary>
    /// Serialize the value to yaml string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToYaml(object? value) =>
        Serializer.Serialize(value);
}