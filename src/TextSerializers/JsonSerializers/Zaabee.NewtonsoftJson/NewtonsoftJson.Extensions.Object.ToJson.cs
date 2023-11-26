namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static string ToJson<TValue>(
        this TValue? value,
        JsonSerializerSettings? settings = null
    ) => NewtonsoftJsonHelper.ToJson(value, settings);

    public static string ToJson(
        this object? value,
        Type type,
        JsonSerializerSettings? settings = null
    ) => NewtonsoftJsonHelper.ToJson(type, value, settings);
}
