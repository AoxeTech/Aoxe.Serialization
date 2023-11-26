namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static byte[] ToBytes(this object? value, Encoding? encoding = null) =>
        YamlDotNetHelper.ToBytes(value, encoding);
}
