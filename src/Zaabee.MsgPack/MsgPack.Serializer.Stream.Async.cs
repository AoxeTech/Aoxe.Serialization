namespace Zaabee.MsgPack;

public static partial class MsgPackSerializer
{
    /// <summary>
    /// Serializes specified object to the memory stream asynchronously.
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
    public static async Task<MemoryStream> PackAsync<T>(T t)
    {
        var ms = new MemoryStream();
        await PackAsync(t, ms);
        return ms;
    }

    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" /> asynchronously.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
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
    public static async Task PackAsync<T>(T t, Stream stream)
    {
        await MessagePackSerializer.Get<T>().PackAsync(stream, t);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserialize object from the <see cref="T:System.IO.Stream" /> asynchronously.
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
    public static async Task<T> UnpackAsync<T>(Stream stream)
    {
        var result = await MessagePackSerializer.Get<T>().UnpackAsync(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}