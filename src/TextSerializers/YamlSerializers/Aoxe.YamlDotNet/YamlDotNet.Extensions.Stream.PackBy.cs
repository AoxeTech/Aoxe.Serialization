namespace Aoxe.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static void PackBy(this Stream? stream, object? value, Encoding? encoding = null) =>
        YamlDotNetHelper.Pack(value, stream, encoding);
}
