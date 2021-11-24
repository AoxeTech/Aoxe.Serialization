namespace Zaabee.ZeroFormatter;

public static partial class ZeroFormatterHelper
{
    public static MemoryStream Pack<T>(T t) => t is null ? new MemoryStream() : ZeroSerializer.Pack(t);

    public static void Pack<T>(T t, Stream stream)
    {
        if (t is null || stream is null) return;
        ZeroSerializer.Pack(t, stream);
    }

    public static MemoryStream Pack(Type type, object obj) =>
        obj is null ? new MemoryStream() : ZeroSerializer.Pack(type, obj);

    public static void Pack(Type type, object obj, Stream stream)
    {
        if (obj is null || stream is null) return;
        ZeroSerializer.Pack(type, obj, stream);
    }

    public static T Unpack<T>(Stream stream) =>
        stream.IsNullOrEmpty()
            ? (T) typeof(T).GetDefaultValue()
            : ZeroSerializer.Unpack<T>(stream);

    public static object Unpack(Type type, Stream stream) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : ZeroSerializer.Unpack(type, stream);
}