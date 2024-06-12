namespace Aoxe.NetJson;

public static partial class NetJsonExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.FromStreamAsync<TValue>(stream, settings);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        NetJSONSettings? settings = null
    ) => NetJsonHelper.FromStreamAsync(type, stream, settings);
}
