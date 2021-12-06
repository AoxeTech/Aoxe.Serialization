namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static string SerializeToJson<TValue>(TValue? value, Options? options = null) =>
        JilSerializer.SerializeToJson(value, options ?? DefaultOptions);

    public static TValue? Deserialize<TValue>(string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.Deserialize<TValue>(json!, options ?? DefaultOptions);

    public static string SerializeToJson(object? value, Options? options = null) =>
        JilSerializer.SerializeToJson(value, options ?? DefaultOptions);

    public static object? Deserialize(Type type, string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.Deserialize(type, json!, options ?? DefaultOptions);
}