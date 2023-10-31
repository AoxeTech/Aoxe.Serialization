namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    public static void Pack(
        object? value,
        Stream? stream = null,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null)
    {
        if (stream is null) return;
        ToBytes(value, tomlSerializerOptions, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}