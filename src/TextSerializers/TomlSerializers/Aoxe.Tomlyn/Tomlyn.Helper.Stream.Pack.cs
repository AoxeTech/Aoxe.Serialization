namespace Aoxe.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    public static void Pack(
        object? value,
        Stream? stream = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null)
            return;
        ToBytes(value, tomlModelOptions, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
