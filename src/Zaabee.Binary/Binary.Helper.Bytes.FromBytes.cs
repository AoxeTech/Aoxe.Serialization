namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : (TValue?)FromBytes(bytes);

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? FromBytes(byte[]? bytes)
    {
        if (bytes is null || bytes.Length is 0) return default;
        using var ms = bytes.ToMemoryStream();
        return FromStream(ms);
    }
}