namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream) =>
        SpanJsonHelper.PackAsync(value, stream);

    public static Task PackToAsync(this object? value, Stream? stream) =>
        SpanJsonHelper.PackAsync(value, stream);
}