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
    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        (TValue?)Deserialize(bytes);

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? Deserialize(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack(ms);
    }
}