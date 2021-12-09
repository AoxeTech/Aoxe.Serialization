namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream ToStream<TValue>(TValue? value, Encoding encoding, Options? options = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding, options);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static Stream ToStream(object? value, Encoding encoding, Options? options = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding, options);
        return ms;
    }
}