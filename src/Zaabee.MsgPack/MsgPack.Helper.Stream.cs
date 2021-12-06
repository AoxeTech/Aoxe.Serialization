namespace Zaabee.MsgPack;

public static partial class MsgPackHelper
{
    public static Stream Pack<TValue>(TValue value) =>
        value is null
            ? Stream.Null
            : MsgPackSerializer.Pack(value);

    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        if (value is null || stream is null) return;
        MsgPackSerializer.Pack(value, stream);
    }

    public static Stream Pack(Type type, object? value) =>
        value is null
            ? Stream.Null
            : MsgPackSerializer.Pack(type, value);

    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        MsgPackSerializer.Pack(type, value, stream);
    }

    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MsgPackSerializer.Unpack<TValue>(stream);

    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : MsgPackSerializer.Unpack(type, stream);
}