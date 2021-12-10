using System.Threading;

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
        if (stream.IsNullOrEmpty()) return default;
        var result = await MessagePackSerializer.Get<TValue>().UnpackAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}