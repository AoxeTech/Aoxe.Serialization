namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        ZeroFormatterHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        ZeroFormatterHelper.ToStream(type, value);
}