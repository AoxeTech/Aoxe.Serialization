namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static TValue? FromBytes<TValue>(this ReadOnlySpan<byte> bytes, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.FromBytes<TValue>(bytes, options);

    public static object? FromBytes(this ReadOnlySpan<byte> bytes, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.FromBytes(type, bytes, options);
}