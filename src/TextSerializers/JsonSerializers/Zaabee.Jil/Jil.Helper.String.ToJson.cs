namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Serializes the given data, returning the output as a string.
    /// 
    /// Pass an Options object to configure the particulars (such as whitespace, and DateTime formats) of
    /// the produced JSON.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToJson<TValue>(TValue? value, Options? options = null) =>
        JSON.Serialize(value, options);

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
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string ToJson(object? value, Options? options = null) =>
        JSON.SerializeDynamic(value, options);
}