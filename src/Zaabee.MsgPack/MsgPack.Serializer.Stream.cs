namespace Zaabee.MsgPack;

public static partial class MsgPackSerializer
{
    /// <summary>
    /// Serializes specified object to the memory stream. />.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to serialize object.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="TValue" /> is not serializable even if it can be deserialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static Stream Pack<TValue>(TValue value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes specified object to the memory stream with default <see cref="T:MsgPack.PackerCompatibilityOptions" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">Failed to serialize <paramref name="value" />. </exception>
    public static Stream Pack(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" />.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="stream" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to serialize object.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="TValue" /> is not serializable even if it can be deserialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        MessagePackSerializer.Get<TValue>().Pack(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" /> with default <see cref="T:MsgPack.PackerCompatibilityOptions" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="stream" /> is <c>null</c>. </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">Failed to serialize <paramref name="value" />. </exception>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        MessagePackSerializer.Get(type).Pack(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

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
    public static TValue? Unpack<TValue>(Stream? stream)
    {
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
    public static object? Unpack(Type type, Stream? stream)
    {
        var result = MessagePackSerializer.Get(type).Unpack(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}