namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static byte[] Serialize(object value) =>
        Pack(value).ReadToEnd();
}