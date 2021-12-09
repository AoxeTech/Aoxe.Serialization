namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void PackTo(this object? value, Stream? stream) =>
        BinarySerializer.Pack(value, stream);
}