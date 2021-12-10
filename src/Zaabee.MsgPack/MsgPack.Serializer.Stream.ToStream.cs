namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
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
    public static Stream ToStream<TValue>(TValue? value)
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
    public static Stream ToStream(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }
}