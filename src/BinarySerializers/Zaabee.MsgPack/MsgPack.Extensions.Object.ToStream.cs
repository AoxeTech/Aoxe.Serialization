namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        MsgPackHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        MsgPackHelper.ToStream(type, value);
}