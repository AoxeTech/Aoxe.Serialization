namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static void PackTo(this object? value, Stream? stream, Encoding? encoding = null) =>
        YamlDotNetHelper.Pack(value, stream, encoding);
}