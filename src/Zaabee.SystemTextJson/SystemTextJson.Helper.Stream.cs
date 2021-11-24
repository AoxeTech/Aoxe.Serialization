namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static MemoryStream Pack<T>(T value, JsonSerializerOptions options = null) =>
        value is null
            ? new MemoryStream()
            : SystemTextJsonSerializer.Pack(value, options ?? DefaultJsonSerializerOptions);

    public static void Pack<T>(T value, Stream stream, JsonSerializerOptions options = null)
    {
        if (value is null || stream is null) return;
        SystemTextJsonSerializer.Pack(value, stream, options ?? DefaultJsonSerializerOptions);
    }

    public static MemoryStream Pack(Type type, object value, JsonSerializerOptions options = null) =>
        value is null
            ? new MemoryStream()
            : SystemTextJsonSerializer.Pack(type, value, options ?? DefaultJsonSerializerOptions);

    public static void Pack(Type type, object value, Stream stream, JsonSerializerOptions options = null)
    {
        if (value is null || stream is null) return;
        SystemTextJsonSerializer.Pack(type, value, stream, options ?? DefaultJsonSerializerOptions);
    }

    public static T Unpack<T>(Stream stream, JsonSerializerOptions options = null) =>
        stream.IsNullOrEmpty()
            ? (T) typeof(T).GetDefaultValue()
            : SystemTextJsonSerializer.Unpack<T>(stream, options ?? DefaultJsonSerializerOptions);

    public static object Unpack(Type type, Stream stream, JsonSerializerOptions options = null) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : SystemTextJsonSerializer.Unpack(type, stream, options ?? DefaultJsonSerializerOptions);
}