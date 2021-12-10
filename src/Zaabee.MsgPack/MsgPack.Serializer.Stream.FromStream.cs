namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Deserialize object from the <see cref="T:System.IO.Stream" />.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="stream" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to deserialize object.
    /// </exception>
    /// <exception cref="T:MsgPack.MessageTypeException">
    /// 	Failed to deserialize object due to invalid stream.
    /// </exception>
    /// <exception cref="T:MsgPack.InvalidMessagePackStreamException">
    /// 	Failed to deserialize object due to invalid stream.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="TValue" /> is not serializable even if it can be serialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static TValue? FromStream<TValue>(Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = MessagePackSerializer.Get<TValue>().Unpack(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserializes object from the <see cref="T:System.IO.Stream" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="stream" /> is <c>null</c>.</exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to deserialize from <paramref name="stream" />.
    /// </exception>
    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = MessagePackSerializer.Get(type).Unpack(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}