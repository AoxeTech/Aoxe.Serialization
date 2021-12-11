namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes) =>
        ZeroFormatterHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[] bytes, Type type) =>
        ZeroFormatterHelper.FromBytes(type, bytes);
}