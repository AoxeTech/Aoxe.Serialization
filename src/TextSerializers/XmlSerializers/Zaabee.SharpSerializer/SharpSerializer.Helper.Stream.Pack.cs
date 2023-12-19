namespace Zaabee.SharpSerializer;

public static partial class SharpSerializerHelper
{
    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (value is null || stream is null)
            return;
        Pack(typeof(TValue), value, stream);
    }

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (value is null || stream is null)
            return;
        var serializer = new Polenter.Serialization.SharpSerializer(DefaultSettings);
        serializer.Serialize(value, stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
