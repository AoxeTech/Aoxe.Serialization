namespace Zaabee.SpanJson;

public static partial class SpanJsonHelper
{
    public static TValue? FromBytes<TValue>(ReadOnlySpan<byte> bytes) =>
        bytes.Length is 0
            ? default
            : JsonSerializer.Generic.Utf8.Deserialize<TValue>(bytes);

    public static object? FromBytes(Type type, ReadOnlySpan<byte> bytes) =>
        bytes.Length is 0
            ? default
            : JsonSerializer.NonGeneric.Utf8.Deserialize(bytes, type);
}