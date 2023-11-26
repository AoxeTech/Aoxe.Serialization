namespace Zaabee.MemoryPack;

public static partial class MemoryPackHelper
{
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null
    )
    {
        if (stream is null)
            return;
        var bufferWriter = new ArrayBufferWriter<byte>();
        MemoryPackSerializer.Serialize(bufferWriter, value, options);
        stream.Write(bufferWriter.WrittenSpan);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Pack(
        Type type,
        object? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null
    )
    {
        if (stream is null)
            return;
        var bufferWriter = new ArrayBufferWriter<byte>();
        MemoryPackSerializer.Serialize(type, bufferWriter, value, options);
        stream.Write(bufferWriter.WrittenSpan);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
