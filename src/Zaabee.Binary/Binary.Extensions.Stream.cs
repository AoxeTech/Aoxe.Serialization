namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        BinaryHelper.Pack(value, stream);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue Unpack<TValue>(this Stream? stream) =>
        BinaryHelper.Unpack<TValue>(stream);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object Unpack(this Stream? stream) =>
        BinaryHelper.Unpack(stream);
}