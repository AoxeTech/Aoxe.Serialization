namespace Aoxe.SpanJson;

public static partial class SpanJsonHelper
{
    public static TValue? FromStream<TValue>(Stream? stream)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = JsonSerializer.Generic.Utf8.Deserialize<TValue>(stream.ReadToEnd());
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = JsonSerializer.NonGeneric.Utf8.Deserialize(stream.ReadToEnd(), type);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
