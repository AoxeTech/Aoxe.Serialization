namespace Zaabee.NetJson;

public static partial class NetJsonExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.ToStream(value, settings);

    public static MemoryStream ToStream(this object? value, NetJSONSettings? settings = null) =>
        NetJsonHelper.ToStream(value, settings);

    public static MemoryStream ToStream(
        this object? value,
        Type type,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.ToStream(type, value, settings);
}
