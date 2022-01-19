namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, Encoding? encoding = null) =>
        YamlDotNetHelper.Pack(value, stream, encoding);
}