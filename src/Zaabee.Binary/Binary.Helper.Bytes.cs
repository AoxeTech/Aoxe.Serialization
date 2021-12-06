namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static byte[] Serialize(object? value) =>
        value is null ? Array.Empty<byte>() : BinarySerializer.Serialize(value);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? Deserialize<TValue>(byte[]? bytes) =>
        bytes.IsNullOrEmpty() ? default : BinarySerializer.Deserialize<TValue>(bytes!);

    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? Deserialize(byte[]? bytes) =>
        bytes.IsNullOrEmpty() ? null : BinarySerializer.Deserialize(bytes!);
}