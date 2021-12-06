namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes) => MsgPackHelper.Deserialize<TValue>(bytes);

    public static object? FromBytes(this byte[] bytes, Type type) => MsgPackHelper.Deserialize(type, bytes);
}