namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        SpanJsonHelper.Pack(value, stream);

    public static void PackTo(this object? value, Stream? stream) =>
        SpanJsonHelper.Pack(value, stream);
}
