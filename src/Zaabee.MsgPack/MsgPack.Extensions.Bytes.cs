namespace Zaabee.MsgPack;

public static partial class MsgPackExtensions
{
    public static T FromBytes<T>(this byte[] bytes) => MsgPackHelper.Deserialize<T>(bytes);

    public static object FromBytes(this byte[] bytes, Type type) => MsgPackHelper.Deserialize(type, bytes);
}