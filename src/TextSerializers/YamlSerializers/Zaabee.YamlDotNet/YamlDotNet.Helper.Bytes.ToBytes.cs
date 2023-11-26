namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    public static byte[] ToBytes(object? value, Encoding? encoding = null) =>
        ToYaml(value).GetBytes(encoding ?? Defaults.Utf8Encoding);
}
