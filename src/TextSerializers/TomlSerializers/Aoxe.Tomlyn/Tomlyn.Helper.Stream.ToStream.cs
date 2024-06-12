namespace Aoxe.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(
        object? value,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, tomlModelOptions, encoding);
        return ms;
    }
}
