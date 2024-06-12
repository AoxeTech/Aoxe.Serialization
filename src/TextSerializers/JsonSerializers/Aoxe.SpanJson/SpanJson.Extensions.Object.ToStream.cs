namespace Aoxe.SpanJson;

public static partial class SpanJsonExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        SpanJsonHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value) => SpanJsonHelper.ToStream(value);
}
