namespace Zaabee.Jil;

public static partial class JilHelper
{
    public static void Serialize<T>(T? t, TextWriter? output, Options? options = null)
    {
        if (output is null) return;
        JilSerializer.Serialize(t, output, options ?? DefaultOptions);
    }

    public static void Serialize(object? obj, TextWriter? output, Options? options = null)
    {
        if (output is null) return;
        JilSerializer.Serialize(obj, output, options ?? DefaultOptions);
    }
}