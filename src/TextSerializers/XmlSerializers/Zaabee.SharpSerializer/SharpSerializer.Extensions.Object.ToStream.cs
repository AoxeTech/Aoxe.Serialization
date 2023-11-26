namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        SharpSerializerHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        SharpSerializerHelper.ToStream(type, value);
}