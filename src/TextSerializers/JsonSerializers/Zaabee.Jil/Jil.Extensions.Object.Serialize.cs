namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static void Serialize<TValue>(
        this TValue? value,
        TextWriter? output,
        Options? options = null
    ) => JilHelper.Serialize(value, output, options);

    public static void Serialize(this object? value, TextWriter? output, Options? options = null) =>
        JilHelper.Serialize(value, output, options);
}
