namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    public static MemoryStream ToStream<TValue>(TValue? value)
    {
        var ms = new MemoryStream();
        DataContractSerializer.Pack(value, ms);
        return ms;
    }

    public static MemoryStream ToStream(Type type, object? value)
    {
        var ms = new MemoryStream();
        DataContractSerializer.Pack(type, value, ms);
        return ms;
    }

    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        DataContractSerializer.Pack(value, stream);
    }

    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        DataContractSerializer.Pack(type, value, stream);
    }

    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : DataContractSerializer.Unpack<TValue>(stream!);

    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : DataContractSerializer.Unpack(type, stream!);
}