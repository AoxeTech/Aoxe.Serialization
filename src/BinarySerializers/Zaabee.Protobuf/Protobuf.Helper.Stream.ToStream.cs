namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Serialize the generic object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serialize the object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(object? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }
}
