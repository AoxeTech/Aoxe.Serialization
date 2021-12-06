namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static byte[] ToBytes<TValue>(this TValue value) =>
        MsgPackHelper.Serialize(value);

    public static Stream ToStream<TValue>(this TValue value) =>
        MsgPackHelper.Pack(value);

    public static void PackTo<TValue>(this TValue value, Stream? stream) =>
        MsgPackHelper.Pack(value, stream);

    public static byte[] ToBytes(this object? value, Type type) =>
        MsgPackHelper.Serialize(type, value);

    public static Stream ToStream(this object? value, Type type) =>
        MsgPackHelper.Pack(type, value);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        MsgPackHelper.Pack(type, value, stream);
}