namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    /// <summary>
    /// Initialize a memory stream by the bytes and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0 ? default : (TValue?)FromBytes(typeof(TValue), bytes);

    /// <summary>
    /// Initialize a memory stream by the bytes and deserialize it.
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
