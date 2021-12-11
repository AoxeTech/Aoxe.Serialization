namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = ZeroFormatterSerializer.Deserialize<TValue>(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}