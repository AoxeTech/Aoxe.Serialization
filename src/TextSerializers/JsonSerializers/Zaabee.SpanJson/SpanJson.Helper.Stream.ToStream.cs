namespace Zaabee.SpanJson;

public static partial class SpanJsonHelper
{
    public static MemoryStream ToStream<TValue>(TValue? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    public static MemoryStream ToStream(object? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }
}