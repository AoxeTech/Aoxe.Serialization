namespace Aoxe.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        DataContractHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        DataContractHelper.FromStream(type, stream);
}
