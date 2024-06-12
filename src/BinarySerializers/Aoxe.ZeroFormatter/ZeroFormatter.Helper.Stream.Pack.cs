namespace Aoxe.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null)
            return;
        ZeroFormatterSerializer.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (stream is null)
            return;
        ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
