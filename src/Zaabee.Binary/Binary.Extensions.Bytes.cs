namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        BinaryHelper.Deserialize<TValue>(bytes);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? FromBytes(this byte[]? bytes) =>
        BinaryHelper.Deserialize(bytes);
}