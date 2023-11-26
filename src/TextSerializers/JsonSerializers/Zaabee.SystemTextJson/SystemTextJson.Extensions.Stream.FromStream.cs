namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.FromStream<TValue>(stream, options);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.FromStream(type, stream, options);
}
