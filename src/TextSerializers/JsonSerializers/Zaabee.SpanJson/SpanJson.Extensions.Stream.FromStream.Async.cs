namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream) =>
        SpanJsonHelper.FromStreamAsync<TValue>(stream);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type) =>
        SpanJsonHelper.FromStreamAsync(type, stream);
}