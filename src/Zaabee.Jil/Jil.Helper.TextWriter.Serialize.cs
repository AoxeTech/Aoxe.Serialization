namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static void Serialize<TValue>(TValue? value, TextWriter? output, Options? options = null)
    {
        if (output is null) return;
        JilSerializer.Serialize(value, output, options ?? DefaultOptions);
    }

    public static void Serialize(object? value, TextWriter? output, Options? options = null)
    {
        if (output is null) return;
        JilSerializer.Serialize(value, output, options ?? DefaultOptions);
    }
}