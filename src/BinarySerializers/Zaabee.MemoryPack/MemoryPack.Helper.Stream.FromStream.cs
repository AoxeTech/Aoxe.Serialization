namespace Zaabee.MemoryPack;

public partial class MemoryPackHelper
{
    public static TValue? FromStream<TValue>(
        Stream? stream,
        MemoryPackSerializerOptions? options = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = MemoryPackSerializer.Deserialize<TValue>(stream.ToReadOnlySequence(), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static object? FromStream(
        Type type,
        Stream? stream,
        MemoryPackSerializerOptions? options = null)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = MemoryPackSerializer.Deserialize(type, stream.ToReadOnlySequence(), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}