namespace Aoxe.MsgPack;

public static partial class MsgPackHelper
{
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
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null)
            return;
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
        if (stream is null)
            return;
        MessagePackSerializer.Get(type).Pack(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
