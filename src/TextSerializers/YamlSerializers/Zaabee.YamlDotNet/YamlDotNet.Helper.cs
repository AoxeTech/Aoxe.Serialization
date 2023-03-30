namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    private static readonly global::YamlDotNet.Serialization.Serializer Serializer = new();
    private static readonly Deserializer Deserializer = new();
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;
}