namespace Zaabee.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static TValue? FromYaml<TValue>(this string? json) =>
        SharpYamlHelper.FromYaml<TValue>(json);

    public static object? FromYaml(this string? json, Type type) =>
        SharpYamlHelper.FromYaml(type, json);
}