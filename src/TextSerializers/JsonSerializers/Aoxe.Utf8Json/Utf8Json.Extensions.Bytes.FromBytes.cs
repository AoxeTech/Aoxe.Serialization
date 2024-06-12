namespace Aoxe.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromBytes<TValue>(
        this byte[]? bytes,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromBytes<TValue>(bytes, resolver);

    public static object? FromBytes(
        this byte[]? bytes,
        Type type,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromBytes(type, bytes, resolver);
}
