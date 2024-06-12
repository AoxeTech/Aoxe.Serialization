namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToStream(value, options);

    public static MemoryStream ToStream(
        this object? value,
        Type type,
        JsonSerializerOptions? options = null
    ) => SystemTextJsonHelper.ToStream(type, value, options);
}
