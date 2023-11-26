namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.Pack(value, stream, options);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.Pack(type, value, stream, options);
}
