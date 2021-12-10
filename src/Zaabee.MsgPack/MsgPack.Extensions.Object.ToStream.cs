namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static Stream ToStream<TValue>(this TValue? value) =>
        MsgPackHelper.ToStream(value);

    public static Stream ToStream(this object? value, Type type) =>
        MsgPackHelper.ToStream(type, value);
}