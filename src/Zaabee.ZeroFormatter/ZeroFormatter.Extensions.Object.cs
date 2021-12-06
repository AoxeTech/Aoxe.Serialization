namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterExtensions
{
    public static byte[] ToBytes<TValue>(this TValue value) =>
        ZeroFormatterHelper.Serialize(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        ZeroFormatterHelper.Serialize(type, value);

    public static Stream ToStream<TValue>(this TValue value) =>
        ZeroFormatterHelper.Pack(value);

    public static Stream ToStream(this object? value, Type type) =>
        ZeroFormatterHelper.Pack(type, value);

    public static void PackTo<TValue>(this TValue value, Stream? stream) =>
        ZeroFormatterHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        ZeroFormatterHelper.Pack(type, value, stream);
}