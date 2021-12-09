namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Serializes an object into a MemoryStream.Will return an empty Stream when the value is null.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static Stream ToStream(object? value) =>
        value is null
            ? Stream.Null
            : BinarySerializer.ToStream(value);
}