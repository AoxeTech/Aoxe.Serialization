namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static Stream ToStream<TValue>(this TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.ToStream(value, options);

    public static Stream ToStream(this object? value, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.ToStream(type, value, options);
}