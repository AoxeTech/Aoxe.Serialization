namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
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

    public static Stream Pack<TValue>(TValue? value) =>
        value is null ? Stream.Null : DataContractSerializer.Pack(value);

    public static Stream Pack(Type type, object? value) =>
        value is null ? Stream.Null : DataContractSerializer.Pack(type, value);

    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : DataContractSerializer.Unpack<TValue>(stream!);

    public static object? Unpack(Type type, Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : DataContractSerializer.Unpack(type, stream!);
}