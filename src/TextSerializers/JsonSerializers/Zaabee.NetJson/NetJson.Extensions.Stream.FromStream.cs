namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.FromStream<TValue>(stream, settings);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.FromStream(type, stream, settings);
}
