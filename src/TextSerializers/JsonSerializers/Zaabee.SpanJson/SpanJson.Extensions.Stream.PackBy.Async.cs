namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value) =>
        SpanJsonHelper.PackAsync(value, stream);

    public static Task PackByAsync(this Stream? stream, object? value) =>
        SpanJsonHelper.PackAsync(value, stream);
}