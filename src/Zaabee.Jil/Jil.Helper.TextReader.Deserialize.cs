namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static TValue? Deserialize<TValue>(TextReader? reader, Options? options = null) =>
        reader is null
            ? default
            : JilSerializer.Deserialize<TValue>(reader, options ?? DefaultOptions);

    public static object? Deserialize(Type type, TextReader? reader, Options? options = null) =>
        reader is null
            ? default
            : JilSerializer.Deserialize(type, reader, options ?? DefaultOptions);
}