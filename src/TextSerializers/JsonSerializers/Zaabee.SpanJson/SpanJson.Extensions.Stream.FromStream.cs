namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        SpanJsonHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        SpanJsonHelper.FromStream(type, stream);
}
