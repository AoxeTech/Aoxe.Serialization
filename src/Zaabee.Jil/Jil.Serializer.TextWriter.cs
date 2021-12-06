namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serializes the given data to the provided TextWriter.
    /// 
    /// Pass an Options object to configure the particulars (such as whitespace, and DateTime formats) of
    /// the produced JSON.  If omitted Options.Default is used, unless JSON.SetDefaultOptions(Options) has been
    /// called with a different Options object.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="output"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Serialize<TValue>(TValue? value, TextWriter output, Options? options) =>
        JSON.Serialize(value, output, options);

    /// <summary>
    /// Serializes the given data to the provided TextWriter.
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
    /// <param name="output"></param>
    /// <param name="options"></param>
    public static void Serialize(object? value, TextWriter output, Options? options) =>
        JSON.SerializeDynamic(value, output, options);
}