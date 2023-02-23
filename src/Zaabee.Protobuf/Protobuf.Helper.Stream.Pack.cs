namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Serialize the generic object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null) return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(object? value, Stream? stream)
    {
        // Cause the protobuf-net will run value.GetType() so this value can not be null.
        if (value is null || stream is null) return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream with a length-prefix.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="prefixStyle"></param>
    /// <param name="fieldNumber"></param>
    public static void PackWithLengthPrefix<TValue>(
        TValue? value,
        Stream? stream,
        PrefixStyle prefixStyle = PrefixStyle.Base128,
        int fieldNumber = 0)
    {
        if (stream is null) return;
        TypeModel.SerializeWithLengthPrefix(stream, value, typeof(TValue), prefixStyle, fieldNumber);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream with a length-prefix.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="prefixStyle"></param>
    /// <param name="fieldNumber"></param>
    public static void PackWithLengthPrefix(
        object? value,
        Stream? stream,
        PrefixStyle prefixStyle = PrefixStyle.Base128,
        int fieldNumber = 0)
    {
        if (value is null || stream is null) return;
        TypeModel.SerializeWithLengthPrefix(stream, value, value.GetType(), prefixStyle, fieldNumber);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}