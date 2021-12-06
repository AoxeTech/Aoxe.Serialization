namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static byte[] Serialize<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.Serialize(value, resolver ?? DefaultJsonFormatterResolver);

    public static ArraySegment<byte> SerializeUnsafe<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeUnsafe(value, resolver ?? DefaultJsonFormatterResolver);

    public static byte[] Serialize(object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.Serialize(value, resolver ?? DefaultJsonFormatterResolver);

    public static byte[] Serialize(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.Serialize(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static ArraySegment<byte>
        SerializeUnsafe(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeUnsafe(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static ArraySegment<byte> SerializeUnsafe(object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeUnsafe(value, resolver ?? DefaultJsonFormatterResolver);

    public static TValue? Deserialize<TValue>(byte[] bytes, IJsonFormatterResolver resolver = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Deserialize<TValue>(bytes, resolver ?? DefaultJsonFormatterResolver);

    public static object? Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Deserialize(type, bytes, resolver ?? DefaultJsonFormatterResolver);
}