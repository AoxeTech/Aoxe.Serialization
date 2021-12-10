using System.Threading;

namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Serializes specified object to the <see cref="T:System.IO.Stream" /> asynchronously.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
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
    public static async Task PackAsync<TValue>(TValue? value, Stream? stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null) return;
        await MessagePackSerializer.Get<TValue>().PackAsync(stream, value, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}