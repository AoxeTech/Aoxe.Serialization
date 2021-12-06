namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Deserialize<TValue>(bytes, options);

    public static object? FromBytes(this byte[] bytes, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Deserialize(type, bytes, options);
}