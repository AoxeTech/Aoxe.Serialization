namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static MemoryStream ToStream<TValue>(
        TValue? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, options, cancellationToken);
        return ms;
    }

    public static MemoryStream ToStream(
        Type type,
        object? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, options, cancellationToken);
        return ms;
    }
}
