namespace Aoxe.SpanJson;

public static partial class SpanJsonHelper
{
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null)
            return;
        stream.Write(ToBytes(value));
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Pack(object? value, Stream? stream)
    {
        if (stream is null)
            return;
        stream.Write(ToBytes(value));
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
