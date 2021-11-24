namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static MemoryStream Pack<T>(T value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? new MemoryStream()
            : Utf8JsonSerializer.Pack(value, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack<T>(T value, Stream stream, IJsonFormatterResolver resolver = null)
    {
        if (value is null || stream is null) return;
        Utf8JsonSerializer.Pack(value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static MemoryStream Pack(object obj, IJsonFormatterResolver resolver = null) =>
        obj is null
            ? new MemoryStream()
            : Utf8JsonSerializer.Pack(obj, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack(object obj, Stream stream, IJsonFormatterResolver resolver = null)
    {
        if (obj is null || stream is null) return;
        Utf8JsonSerializer.Pack(obj, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static MemoryStream Pack(Type type, object obj, IJsonFormatterResolver resolver = null) =>
        obj is null
            ? new MemoryStream()
            : Utf8JsonSerializer.Pack(type, obj, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack(Type type, object obj, Stream stream, IJsonFormatterResolver resolver = null)
    {
        if (obj is null || stream is null) return;
        Utf8JsonSerializer.Pack(type, obj, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static T Unpack<T>(Stream stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? (T) typeof(T).GetDefaultValue()
            : Utf8JsonSerializer.Unpack<T>(stream, resolver ?? DefaultJsonFormatterResolver);

    public static object Unpack(Type type, Stream stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : Utf8JsonSerializer.Unpack(type, stream, resolver ?? DefaultJsonFormatterResolver);
}