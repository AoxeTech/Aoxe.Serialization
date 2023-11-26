namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        DataContractHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        DataContractHelper.ToStream(type, value);
}
