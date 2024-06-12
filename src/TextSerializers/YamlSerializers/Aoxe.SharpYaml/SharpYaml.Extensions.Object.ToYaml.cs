namespace Aoxe.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static string ToYaml<TValue>(this TValue? value) => SharpYamlHelper.ToYaml(value);

    public static string ToYaml(this object? value, Type type) =>
        SharpYamlHelper.ToYaml(type, value);
}
