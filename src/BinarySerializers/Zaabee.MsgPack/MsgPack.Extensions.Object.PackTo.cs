namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        MsgPackHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        MsgPackHelper.Pack(type, value, stream);
}
