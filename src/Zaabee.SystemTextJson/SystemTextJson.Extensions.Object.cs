namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static string ToJson<TValue>(this TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.SerializeToJson(value, options);

    public static string ToJson(this object? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.SerializeToJson(value, options);

    public static string ToJson(this object? value, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.SerializeToJson(type, value, options);

    public static byte[] ToBytes<TValue>(this TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Serialize(value, options);

    public static byte[] ToBytes(this object? value, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Serialize(type, value, options);

    public static Stream ToStream<TValue>(this TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(value, options);

    public static Stream ToStream(this object? value, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(type, value, options);

    public static void PackTo<TValue>(this TValue? value, Stream? stream, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(value, stream, options);

    public static void PackTo(this object? value, Type type, Stream? stream, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(type, value, stream, options);
}