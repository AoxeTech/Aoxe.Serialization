namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }
}