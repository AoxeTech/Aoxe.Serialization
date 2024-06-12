namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static string ToJson<TValue>(
        this TValue? value,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToJson(value, options);

    public static string ToJson(
        this object? value,
        Type type,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToJson(type, value, options);
}
