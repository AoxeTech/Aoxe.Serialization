namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void PackBy(this Stream? stream, object? value) =>
        BinarySerializer.Pack(value, stream);
}