namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.Pack(value, stream, options);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.Pack(type, value, stream, options);
}
