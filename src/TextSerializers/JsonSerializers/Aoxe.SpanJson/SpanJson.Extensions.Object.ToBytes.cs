namespace Aoxe.SpanJson;

public static partial class SpanJsonExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) => SpanJsonHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value) => SpanJsonHelper.ToBytes(value);
}
