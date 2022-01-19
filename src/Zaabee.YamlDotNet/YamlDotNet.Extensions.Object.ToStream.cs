namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value, Encoding? encoding = null) =>
        YamlDotNetHelper.ToStream(value, encoding);
}