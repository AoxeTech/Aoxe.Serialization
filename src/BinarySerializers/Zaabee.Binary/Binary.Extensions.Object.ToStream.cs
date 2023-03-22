namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static MemoryStream ToStream(this object? value) =>
        BinaryHelper.ToStream(value);
}