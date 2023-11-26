namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Deserialize the stream to a generic object.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = TypeModel.Deserialize<TValue>(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserialize the stream to an object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = TypeModel.Deserialize(stream, null, type);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
