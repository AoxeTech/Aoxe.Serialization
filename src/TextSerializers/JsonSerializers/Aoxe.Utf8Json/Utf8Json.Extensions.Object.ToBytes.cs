namespace Aoxe.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.ToBytes(value, resolver);

    public static byte[] ToBytes(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToBytes(value, resolver);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.ToBytes(type, value, resolver);
}
