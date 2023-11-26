namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask PackAsync(
        object? value,
        Stream? stream = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await ToBytes(value, tomlModelOptions, encoding).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
