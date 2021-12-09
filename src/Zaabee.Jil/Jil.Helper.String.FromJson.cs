namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static TValue? FromJson<TValue>(string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.FromJson<TValue>(json!, options ?? DefaultOptions);

    public static object? FromJson(Type type, string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JilSerializer.FromJson(type, json!, options ?? DefaultOptions);
}