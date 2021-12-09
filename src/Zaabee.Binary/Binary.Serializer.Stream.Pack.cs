namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    /// <summary>
    /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void Pack(object? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        _binaryFormatter ??= new BinaryFormatter();
        _binaryFormatter.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}