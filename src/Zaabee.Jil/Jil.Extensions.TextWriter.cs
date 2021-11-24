namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static void WriteJson<T>(this TextWriter? textWriter, T? t, Options? options = null) =>
        JilHelper.Serialize(t, textWriter, options);

    public static void WriteJson(this TextWriter? textWriter, object? obj, Options? options = null) =>
        JilHelper.Serialize(obj, textWriter, options);
}