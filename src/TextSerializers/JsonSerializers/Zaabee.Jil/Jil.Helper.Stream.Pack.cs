namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream = null,
        Options? options = null,
        Encoding? encoding = null
    )
    {
        if (stream is null)
            return;
        ToBytes(value, options, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    public static void Pack(
        object? value,
        Stream? stream = null,
        Options? options = null,
        Encoding? encoding = null
    )
    {
        if (stream is null)
            return;
        ToBytes(value, options, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
