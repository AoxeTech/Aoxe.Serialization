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
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream = null,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null)
            return;
        ToBytes(value, tomlSerializerOptions, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    public static void Pack(
        Type type,
        object? value,
        Stream? stream = null,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null)
            return;
        ToBytes(type, value, tomlSerializerOptions, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
