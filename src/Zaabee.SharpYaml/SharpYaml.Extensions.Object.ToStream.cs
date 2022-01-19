namespace Zaabee.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        SharpYamlHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        SharpYamlHelper.ToStream(type, value);
}