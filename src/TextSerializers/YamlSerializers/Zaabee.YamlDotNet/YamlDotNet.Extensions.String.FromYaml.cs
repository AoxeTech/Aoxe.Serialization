namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static TValue? FromYaml<TValue>(this string? json) =>
        YamlDotNetHelper.FromYaml<TValue>(json);

    public static object? FromYaml(this string? json, Type type) =>
        YamlDotNetHelper.FromYaml(type, json);
}
