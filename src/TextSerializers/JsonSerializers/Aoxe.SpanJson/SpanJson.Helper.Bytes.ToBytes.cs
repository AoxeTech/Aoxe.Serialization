namespace Aoxe.SpanJson;

public static partial class SpanJsonHelper
{
    public static byte[] ToBytes<TValue>(TValue? value) =>
        JsonSerializer.Generic.Utf8.Serialize(value);

    public static byte[] ToBytes(object? value) => JsonSerializer.NonGeneric.Utf8.Serialize(value);
}
