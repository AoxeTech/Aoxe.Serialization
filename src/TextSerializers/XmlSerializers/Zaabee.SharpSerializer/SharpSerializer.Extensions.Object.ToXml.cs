namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static string ToXml<TValue>(this TValue? value) =>
        SharpSerializerHelper.ToXml(value);

    public static string ToXml(this object? value, Type type) =>
        SharpSerializerHelper.ToXml(type, value);
}