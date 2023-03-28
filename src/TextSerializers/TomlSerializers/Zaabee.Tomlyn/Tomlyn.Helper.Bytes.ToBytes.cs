namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Serialize the object to toml string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(
        object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        ToToml(value, tomlModelOptions).GetBytes(encoding ?? DefaultEncoding);
}