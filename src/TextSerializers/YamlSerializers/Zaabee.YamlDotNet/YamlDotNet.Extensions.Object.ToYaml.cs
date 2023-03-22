namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static string ToYaml(this object? value) =>
        YamlDotNetHelper.ToYaml(value);
}