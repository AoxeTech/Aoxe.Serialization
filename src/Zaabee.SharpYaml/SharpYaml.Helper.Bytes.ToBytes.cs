namespace Zaabee.SharpYaml;

public static partial class SharpYamlHelper
{
    public static byte[] ToBytes<TValue>(TValue? value) =>
        ToStream(value).ToArray();

    public static byte[] ToBytes(Type type, object? value) =>
        ToStream(type, value).ToArray();
}