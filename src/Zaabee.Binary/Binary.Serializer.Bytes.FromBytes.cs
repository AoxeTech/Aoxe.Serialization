namespace Zaabee.Binary;

public static partial class BinarySerializer
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
        bytes.IsNullOrEmpty()
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
        if (bytes.IsNullOrEmpty()) return default;
        using var ms = new MemoryStream(bytes!);
        return FromStream(ms);
    }
}