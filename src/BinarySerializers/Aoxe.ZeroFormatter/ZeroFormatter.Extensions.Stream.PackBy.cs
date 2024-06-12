namespace Aoxe.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        ZeroFormatterHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        ZeroFormatterHelper.Pack(type, value, stream);
}
