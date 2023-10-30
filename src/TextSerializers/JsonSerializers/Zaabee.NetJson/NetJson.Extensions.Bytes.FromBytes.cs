namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes, NetJSONSettings? settings = null) =>
        NetJsonHelper.FromBytes<TValue>(bytes, settings);

    public static object? FromBytes(this byte[]? bytes, Type type, NetJSONSettings? settings = null) =>
        NetJsonHelper.FromBytes(type, bytes, settings);
}