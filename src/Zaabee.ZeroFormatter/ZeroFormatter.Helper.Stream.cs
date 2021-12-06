namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    public static Stream Pack<TValue>(TValue value) => value is null ? Stream.Null : ZeroSerializer.Pack(value);

    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        if (value is null || stream is null) return;
        ZeroSerializer.Pack(value, stream);
    }

    public static Stream Pack(Type type, object? value) =>
        value is null ? Stream.Null : ZeroSerializer.Pack(type, value);

    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        ZeroSerializer.Pack(type, value, stream);
    }

    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Unpack<TValue>(stream);

    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : ZeroSerializer.Unpack(type, stream);
}