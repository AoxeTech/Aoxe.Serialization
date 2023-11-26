namespace Zaabee.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        SharpYamlHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        SharpYamlHelper.FromBytes(type, bytes);
}
