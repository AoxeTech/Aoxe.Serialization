namespace Zaabee.MemoryPack;

public static partial class MemoryPackHelper
{
    public static MemoryStream ToStream<TValue>(
        TValue? value,
        MemoryPackSerializerOptions? options = null
    )
    {
        var ms = new MemoryStream();
        Pack(value, ms, options);
        return ms;
    }

    public static MemoryStream ToStream(
        Type type,
        object? value,
        MemoryPackSerializerOptions? options = null
    )
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, options);
        return ms;
    }
}
