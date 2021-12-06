namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static byte[] Serialize<TValue>(TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.Serialize(value, options ?? DefaultJsonSerializerOptions);

    public static byte[] Serialize(Type type, object? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.Serialize(type, value, options ?? DefaultJsonSerializerOptions);

    public static TValue? Deserialize<TValue>(ReadOnlySpan<byte> bytes, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.Deserialize<TValue>(bytes, options ?? DefaultJsonSerializerOptions);

    public static object? Deserialize(Type type, ReadOnlySpan<byte> bytes, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.Deserialize(type, bytes, options ?? DefaultJsonSerializerOptions);
}