namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue? value,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(value, options);

    public static Task<MemoryStream> ToStreamAsync(this object? value, Type type,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(type, value, options);

    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(value, stream, options);

    public static Task PackToAsync(this object? value, Type type, Stream? stream,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(type, value, stream, options);
}