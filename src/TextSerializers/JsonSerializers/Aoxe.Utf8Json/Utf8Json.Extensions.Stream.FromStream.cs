namespace Aoxe.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromStream<TValue>(stream, resolver);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromStream(type, stream, resolver);
}
