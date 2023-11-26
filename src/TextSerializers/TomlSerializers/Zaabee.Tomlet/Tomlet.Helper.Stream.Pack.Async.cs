namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream = null,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await ToBytes(value, tomlSerializerOptions, encoding)
            .WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream = null,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await ToBytes(type, value, tomlSerializerOptions, encoding)
            .WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
