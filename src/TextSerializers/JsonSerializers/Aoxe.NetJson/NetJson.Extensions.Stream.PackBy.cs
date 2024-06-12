namespace Aoxe.NetJson;

public static partial class NetJsonExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.Pack(value, stream, settings);

    public static void PackBy(
        this Stream? stream,
        object? value,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.Pack(value, stream, settings);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.Pack(type, value, stream, settings);
}
