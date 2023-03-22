namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Deserializes JSON from the given string.
    /// 
    /// Pass an Options object to specify the particulars (such as DateTime formats) of
    /// the JSON being deserialized.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JSON.Deserialize<TValue>(json, options);

    /// <summary>
    /// Deserializes JSON from the given string as the passed type.
    /// 
    /// This is equivalent to calling Deserialize&lt;T&gt;(string, Options), except
    /// without requiring a generic parameter.  For true dynamic deserialization, you
    /// should use DeserializeDynamic instead.
    /// 
    /// Pass an Options object to specify the particulars (such as DateTime formats) of
    /// the JSON being deserialized.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? FromJson(Type type, string? json, Options? options = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : JSON.Deserialize(json, type, options);
}