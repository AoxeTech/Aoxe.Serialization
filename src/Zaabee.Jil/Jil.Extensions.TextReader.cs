namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static TValue? ReadJson<TValue>(this TextReader? textReader, Options? options = null) =>
        JilHelper.Deserialize<TValue>(textReader, options);

    public static object? ReadJson(this TextReader? textReader, Type type, Options? options = null) =>
        JilHelper.Deserialize(type, textReader, options);
}