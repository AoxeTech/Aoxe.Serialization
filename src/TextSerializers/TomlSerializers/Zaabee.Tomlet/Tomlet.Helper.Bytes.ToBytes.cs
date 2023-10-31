namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Serialize the object to toml string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        ToToml(value, tomlSerializerOptions).GetBytes(encoding ?? Defaults.Utf8Encoding);
}