namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.ToStreamAsync(value, options);

    public static Task<MemoryStream> ToStreamAsync(this object? value, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.ToStreamAsync(type, value, options);
}