namespace Aoxe.SpanJson;

public static partial class SpanJsonExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        SpanJsonHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        SpanJsonHelper.FromBytes(type, bytes);
}
