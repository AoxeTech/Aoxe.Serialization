namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream, Encoding? encoding = null) =>
        YamlDotNetHelper.FromStream<TValue>(stream, encoding);

    public static object? FromStream(this Stream? stream, Type type, Encoding? encoding = null) =>
        YamlDotNetHelper.FromStream(type, stream, encoding);
}
