namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        ZeroFormatterHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        ZeroFormatterHelper.Pack(type, value, stream);
}