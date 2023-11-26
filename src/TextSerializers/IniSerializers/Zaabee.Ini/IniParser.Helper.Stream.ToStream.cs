namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Serialize the object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value, Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding);
        return ms;
    }

    /// <summary>
    /// Serialize the object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(object? value, Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding);
        return ms;
    }

    /// <summary>
    /// Serialize the object to a memory stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value, Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, encoding);
        return ms;
    }
}
