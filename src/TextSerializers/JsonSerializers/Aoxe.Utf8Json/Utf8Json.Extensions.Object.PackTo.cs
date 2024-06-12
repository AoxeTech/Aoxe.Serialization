namespace Aoxe.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackTo(
        this object? value,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.Pack(type, value, stream, resolver);
}
