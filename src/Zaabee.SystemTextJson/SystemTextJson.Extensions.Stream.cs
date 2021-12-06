namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(value, stream, options);

    public static void PackBy(this Stream? stream, Type type, object? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Pack(type, value, stream, options);

    public static TValue? Unpack<TValue>(this Stream? stream, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Unpack<TValue>(stream, options);

    public static object? Unpack(this Stream? stream, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Unpack(type, stream, options);
}