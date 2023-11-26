namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        ZeroFormatterHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        ZeroFormatterHelper.FromStream(type, stream);
}
