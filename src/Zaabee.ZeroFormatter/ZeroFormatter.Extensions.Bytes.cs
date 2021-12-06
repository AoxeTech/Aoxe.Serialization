namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes) =>
        ZeroFormatterHelper.Deserialize<TValue>(bytes);

    public static object? FromBytes(this byte[] bytes, Type type) =>
        ZeroFormatterHelper.Deserialize(type, bytes);
}