namespace Aoxe.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) => SharpYamlHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        SharpYamlHelper.ToBytes(type, value);
}
