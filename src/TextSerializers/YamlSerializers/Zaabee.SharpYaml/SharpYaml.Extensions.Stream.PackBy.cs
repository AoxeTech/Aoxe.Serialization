namespace Zaabee.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        SharpYamlHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        SharpYamlHelper.Pack(type, value, stream);
}
