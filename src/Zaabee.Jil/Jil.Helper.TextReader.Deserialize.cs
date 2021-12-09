namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Deserializes JSON from the given TextReader.
    /// 
    /// Pass an Options object to specify the particulars (such as DateTime formats) of
    /// the JSON being deserialized.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(TextReader? reader, Options? options = null) =>
        reader is null
            ? default
            : JSON.Deserialize<TValue>(reader, options);

    /// <summary>
    /// Deserializes JSON from the given TextReader as the passed type.
    /// 
    /// This is equivalent to calling Deserialize&lt;T&gt;(TextReader, Options), except
    /// without requiring a generic parameter.  For true dynamic deserialization, you
    /// should use DeserializeDynamic instead.
    /// 
    /// Pass an Options object to specify the particulars (such as DateTime formats) of
    /// the JSON being deserialized.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="reader"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, TextReader? reader, Options? options = null) =>
        reader is null
            ? default
            : JSON.Deserialize(reader, type, options);
}