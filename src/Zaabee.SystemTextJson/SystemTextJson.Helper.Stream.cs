namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static Stream Pack<TValue>(TValue? value, JsonSerializerOptions? options = null) =>
        value is null
            ? Stream.Null
            : SystemTextJsonSerializer.Pack(value, options ?? DefaultJsonSerializerOptions);

    public static void Pack<TValue>(TValue? value, Stream? stream, JsonSerializerOptions? options = null)
    {
        if (value is null || stream is null) return;
        SystemTextJsonSerializer.Pack(value, stream, options ?? DefaultJsonSerializerOptions);
    }

    public static Stream Pack(Type type, object? value, JsonSerializerOptions? options = null) =>
        value is null
            ? Stream.Null
            : SystemTextJsonSerializer.Pack(type, value, options ?? DefaultJsonSerializerOptions);

    public static void Pack(Type type, object? value, Stream? stream, JsonSerializerOptions? options = null)
    {
        if (value is null || stream is null) return;
        SystemTextJsonSerializer.Pack(type, value, stream, options ?? DefaultJsonSerializerOptions);
    }

    public static TValue? Unpack<TValue>(Stream? stream, JsonSerializerOptions? options = null) =>
        stream is null || stream.Length is 0
            ? default
            : SystemTextJsonSerializer.Unpack<TValue>(stream!, options ?? DefaultJsonSerializerOptions);

    public static object? Unpack(Type type, Stream? stream, JsonSerializerOptions? options = null) =>
        stream is null || stream.Length is 0
            ? default
            : SystemTextJsonSerializer.Unpack(type, stream!, options ?? DefaultJsonSerializerOptions);
}