namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serializes the given data, returning the output as a string.
    /// 
    /// Pass an Options object to configure the particulars (such as whitespace, and DateTime formats) of
    /// the produced JSON.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string SerializeToJson<T>(T? t, Options? options) =>
        JSON.Serialize(t, options);

    /// <summary>
    /// Serializes the given data, returning it as a string.
    /// 
    /// Pass an Options object to configure the particulars (such as whitespace, and DateTime formats) of
    /// the produced JSON.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// 
    /// Unlike Serialize, this method will inspect the Type of data to determine what serializer to invoke.
    /// This is not as fast as calling Serialize with a known type.
    /// 
    /// Objects with participate in the DLR will be serialized appropriately, all other types
    /// will be serialized via reflection.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string SerializeToJson(object? obj, Options? options) =>
        JSON.SerializeDynamic(obj, options);

    /// <summary>
    /// Deserializes JSON from the given string.
    /// 
    /// Pass an Options object to specify the particulars (such as DateTime formats) of
    /// the JSON being deserialized.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(string json, Options? options) =>
        JSON.Deserialize<T>(json, options);

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
    public static object Deserialize(Type type, string json, Options? options) =>
        JSON.Deserialize(json, type, options);
}