namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream, NetJSONSettings? settings = null) =>
        NetJsonHelper.Pack(value, stream, settings);

    public static void PackTo(this object? value, Stream? stream, NetJSONSettings? settings = null) =>
        NetJsonHelper.Pack(value, stream, settings);

    public static void PackTo(this object? value, Type type, Stream? stream, NetJSONSettings? settings = null) =>
        NetJsonHelper.Pack(type, value, stream, settings);
}