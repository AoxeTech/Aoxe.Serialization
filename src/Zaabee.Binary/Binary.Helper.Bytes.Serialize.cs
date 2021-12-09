namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static byte[] Serialize(object? value) =>
        value is null
            ? Array.Empty<byte>()
            : BinarySerializer.ToBytes(value);
}