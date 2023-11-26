namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToBytes(value, options);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToBytes(type, value, options);
}
