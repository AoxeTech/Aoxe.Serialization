namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.Pack(value, stream, resolver);

    public static void PackBy(this Stream? stream, Type type, object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.Pack(type, value, stream, resolver);
}