using System.Threading;

namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    /// <summary>
    /// Serializes specified object to the memory stream asynchronously.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="T:System.Runtime.Serialization.SerializationException">
    /// 	Failed to serialize object.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// 	<typeparamref name="TValue" /> is not serializable even if it can be deserialized.
    /// </exception>
    /// <seealso cref="P:Capabilities" />
    public static async Task<MemoryStream> ToStreamAsync<TValue>(TValue? value,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, cancellationToken);
        return ms;
    }
}