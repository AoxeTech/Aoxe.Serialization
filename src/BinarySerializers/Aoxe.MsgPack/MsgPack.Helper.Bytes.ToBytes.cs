namespace Aoxe.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value)
    {
        using var ms = ToStream(value);
        return ms.ToArray();
    }

    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value)
    {
        using var ms = ToStream(type, value);
        return ms.ToArray();
    }
}
