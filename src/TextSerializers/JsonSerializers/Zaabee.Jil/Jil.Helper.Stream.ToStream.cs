namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(
        TValue? value,
        Options? options = null,
        Encoding? encoding = null
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, options, encoding);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(
        object? value,
        Options? options = null,
        Encoding? encoding = null
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, options, encoding);
        return ms;
    }
}
