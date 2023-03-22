namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Deserialize object from the <see cref="T:System.IO.Stream" /> asynchronously.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
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
    public static async Task<TValue?> FromStreamAsync<TValue>(Stream? stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = await MessagePackSerializer.Get<TValue>().UnpackAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// 	Deserialize object with specified <see cref="T:System.IO.Stream" /> asynchronously.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="P:System.Threading.CancellationToken.None" />.</param>
    /// <returns>
    /// 	A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    /// 	The value of the <c>TResult</c> parameter contains the deserialized object.
    /// </returns>
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
    /// 	The type of deserializing is not serializable even if it can be serialized.
    /// </exception>
    /// <remarks>
    /// 	You must call <see cref="M:MsgPack.Unpacker.Read" /> at least once in advance.
    /// 	Or, you will get a default value of the object.
    /// </remarks>
    /// <seealso cref="P:MsgPack.Serialization.MessagePackSerializer.Capabilities" />
    public static async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var unpacker = Unpacker.Create(stream);
        await unpacker.ReadAsync(cancellationToken);
        var result = await MessagePackSerializer.Get(type).UnpackFromAsync(unpacker, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}