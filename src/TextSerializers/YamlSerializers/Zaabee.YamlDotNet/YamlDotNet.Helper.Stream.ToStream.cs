namespace Zaabee.YamlDotNet;

public static partial class YamlDotNetHelper
{
    /// <summary>
    /// Serialize the value to yaml text and write it to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(object? value, Encoding? encoding = null) =>
        new(ToBytes(value, encoding ?? Defaults.Utf8Encoding));
}
