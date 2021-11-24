namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static void PackBy<T>(this Stream stream, T obj, JsonSerializerOptions options = null) =>
        SystemTextJsonHelper.Pack(obj, stream, options);

    public static void PackBy(this Stream stream, Type type, object obj, JsonSerializerOptions options = null) =>
        SystemTextJsonHelper.Pack(type, obj, stream, options);

    public static T Unpack<T>(this Stream stream, JsonSerializerOptions options = null) =>
        SystemTextJsonHelper.Unpack<T>(stream, options);

    public static object Unpack(this Stream stream, Type type, JsonSerializerOptions options = null) =>
        SystemTextJsonHelper.Unpack(type, stream, options);
}