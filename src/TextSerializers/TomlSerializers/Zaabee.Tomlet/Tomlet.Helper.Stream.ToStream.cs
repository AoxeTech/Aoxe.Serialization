namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(
        object? value,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, tomlSerializerOptions, encoding);
        return ms;
    }
}