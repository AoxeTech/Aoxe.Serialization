namespace Zaabee.MemoryPack;

public partial class MemoryPackHelper
{
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null)
    {
        if (stream is null) return;
        var bufferWriter = new ArrayBufferWriter<byte>(99999);
        MemoryPackSerializer.Serialize(bufferWriter, value, options);
        stream.Write(bufferWriter.WrittenSpan);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Pack(
        Type type,
        object? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null)
    {
        if (stream is null) return;
        var bufferWriter = new ArrayBufferWriter<byte>(99999);
        MemoryPackSerializer.Serialize(type, bufferWriter, value, options);
        stream.Write(bufferWriter.WrittenSpan);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}