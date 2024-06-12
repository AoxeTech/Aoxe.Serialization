namespace Aoxe.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Serialize the generic object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null)
            return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(object? value, Stream? stream)
    {
        // Cause the protobuf-net will run value.GetType() so this value can not be null.
        if (value is null || stream is null)
            return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
