namespace Zaabee.Binary;

public static partial class BinaryExtensions
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        BinarySerializer.FromStream<TValue>(stream);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? FromStream(this Stream? stream) =>
        BinarySerializer.FromStream(stream);
}