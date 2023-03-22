namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        MsgPackHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        MsgPackHelper.Pack(type, value, stream);
}