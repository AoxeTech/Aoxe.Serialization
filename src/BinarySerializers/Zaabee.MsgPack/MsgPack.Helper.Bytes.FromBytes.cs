namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes)
    {
        if (bytes is null || bytes.Length is 0)
            return default;
        using var ms = bytes.ToMemoryStream();
        return FromStream<TValue>(ms);
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[]? bytes)
    {
        if (bytes is null || bytes.Length is 0)
            return default;
        using var ms = bytes.ToMemoryStream();
        return FromStream(type, ms);
    }
}
