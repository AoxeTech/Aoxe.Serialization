namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static void WriteJson<TValue>(
        this TextWriter? textWriter,
        TValue? value,
        Options? options = null
    ) => JilHelper.Serialize(value, textWriter, options);

    public static void WriteJson(
        this TextWriter? textWriter,
        object? value,
        Options? options = null
    ) => JilHelper.Serialize(value, textWriter, options);
}
