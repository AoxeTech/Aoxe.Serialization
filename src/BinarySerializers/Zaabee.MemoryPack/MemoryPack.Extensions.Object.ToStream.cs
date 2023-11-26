namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.ToStream(value, options);

    public static MemoryStream ToStream(
        this object? value,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.ToStream(type, value, options);
}
