namespace Aoxe.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes, Encoding? encoding = null) =>
        YamlDotNetHelper.FromBytes<TValue>(bytes, encoding);

    public static object? FromBytes(this byte[]? bytes, Type type, Encoding? encoding = null) =>
        YamlDotNetHelper.FromBytes(type, bytes, encoding);
}
