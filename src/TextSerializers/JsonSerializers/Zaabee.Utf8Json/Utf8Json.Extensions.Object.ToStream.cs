namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(value, resolver);

    public static MemoryStream ToStream(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(value, resolver);

    public static MemoryStream ToStream(this object? value, Type type, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToStream(type, value, resolver);
}