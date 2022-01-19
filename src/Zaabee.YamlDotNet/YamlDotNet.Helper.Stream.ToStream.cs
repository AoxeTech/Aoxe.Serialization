namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    /// <summary>
    /// Convert the provided value to yaml text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(object? value, Encoding? encoding = null) =>
        new(ToBytes(value, encoding ?? DefaultEncoding));
}