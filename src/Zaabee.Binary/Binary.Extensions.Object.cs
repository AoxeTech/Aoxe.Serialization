namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static byte[] ToBytes(this object? value) =>
        BinaryHelper.Serialize(value);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static Stream ToStream(this object? value) =>
        BinaryHelper.Pack(value);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void PackTo(this object? value, Stream? stream) =>
        BinaryHelper.Pack(value, stream);
}