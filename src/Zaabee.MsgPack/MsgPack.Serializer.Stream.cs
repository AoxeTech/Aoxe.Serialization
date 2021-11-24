namespace Zaabee.MsgPack;

public static partial class MsgPackSerializer
{
    /// <summary>
    /// Serializes specified object to the memory stream. />.
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to serialize object.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="T" /> is not serializable even if it can be deserialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static MemoryStream Pack<T>(T t)
    {
        var ms = new MemoryStream();
        Pack(t, ms);
        return ms;
    }

    /// <summary>
    /// Serializes specified object to the memory stream with default <see cref="T:MsgPack.PackerCompatibilityOptions" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">Failed to serialize <paramref name="obj" />. </exception>
    public static MemoryStream Pack(Type type, object obj)
    {
        var ms = new MemoryStream();
        Pack(type, obj, ms);
        return ms;
    }

    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" />.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="stream" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to serialize object.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="T" /> is not serializable even if it can be deserialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static void Pack<T>(T t, Stream stream)
    {
        MessagePackSerializer.Get<T>().Pack(stream, t);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" /> with default <see cref="T:MsgPack.PackerCompatibilityOptions" />.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <exception cref="T:System.ArgumentNullException"><paramref name="stream" /> is <c>null</c>. </exception>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">Failed to serialize <paramref name="obj" />. </exception>
    public static void Pack(Type type, object obj, Stream stream)
    {
        MessagePackSerializer.Get(type).Pack(stream, obj);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserialize object from the <see cref="T:System.IO.Stream" />.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
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
    /// 	<typeparamref name="T" /> is not serializable even if it can be serialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static T Unpack<T>(Stream stream)
    {
        var result = MessagePackSerializer.Get<T>().Unpack(stream);
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
    public static object Unpack(Type type, Stream stream)
    {
        var result = MessagePackSerializer.Get(type).Unpack(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}