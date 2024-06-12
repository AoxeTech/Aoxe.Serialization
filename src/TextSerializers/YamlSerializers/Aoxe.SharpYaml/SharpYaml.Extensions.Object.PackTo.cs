namespace Aoxe.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        SharpYamlHelper.Pack(typeof(TValue), value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        SharpYamlHelper.Pack(type, value, stream);
}
