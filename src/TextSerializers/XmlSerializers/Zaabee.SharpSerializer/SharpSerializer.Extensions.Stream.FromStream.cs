namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        SharpSerializerHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        SharpSerializerHelper.FromStream(type, stream);
}