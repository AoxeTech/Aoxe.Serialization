namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToBytes(value, settings);

    public static byte[] ToBytes(this object? value, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToBytes(value, settings);

    public static byte[] ToBytes(this object? value, Type type, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToBytes(type, value, settings);
}
