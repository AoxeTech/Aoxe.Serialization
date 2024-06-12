namespace Aoxe.SpanJson;

public static partial class SpanJsonExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        SpanJsonHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, object? value) =>
        SpanJsonHelper.Pack(value, stream);
}
