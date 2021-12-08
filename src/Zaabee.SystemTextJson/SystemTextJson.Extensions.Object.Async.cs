namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static async Task<Stream> ToStreamAsync<TValue>(this TValue? value,
        JsonSerializerOptions? options = null) =>
        await SystemTextJsonHelper.PackAsync(value, options);

    public static async Task<Stream> ToStreamAsync(this object? value, Type type,
        JsonSerializerOptions? options = null) =>
        await SystemTextJsonHelper.PackAsync(type, value, options);

    public static async Task PackToAsync<TValue>(this TValue? value, Stream? stream,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(value, stream, options);

    public static async Task PackToAsync(this object? value, Type type, Stream? stream,
        JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.PackAsync(type, value, stream, options);
}