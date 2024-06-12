namespace Aoxe.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) => ZeroFormatterHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        ZeroFormatterHelper.ToBytes(type, value);
}
