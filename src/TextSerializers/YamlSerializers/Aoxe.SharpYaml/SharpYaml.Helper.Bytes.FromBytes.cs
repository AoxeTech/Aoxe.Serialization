namespace Aoxe.SharpYaml;

public static partial class SharpYamlHelper
{
    public static TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null ? default : FromStream<TValue>(bytes.ToMemoryStream());

    public static object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null ? default : FromStream(type, bytes.ToMemoryStream());
}
