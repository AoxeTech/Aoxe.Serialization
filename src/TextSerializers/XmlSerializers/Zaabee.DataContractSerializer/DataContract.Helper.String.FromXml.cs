namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    /// <summary>
    /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
    /// </summary>
    /// <param name="xml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromXml<TValue>(string? xml) =>
        string.IsNullOrWhiteSpace(xml) ? default : (TValue?)FromXml(typeof(TValue), xml);

    /// <summary>
    /// Encode the xml to a bytes and initialize a memory stream by it,deserialize to a object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static object? FromXml(Type type, string? xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
            return default;
        using var ms = Encoding.UTF8.GetBytes(xml).ToMemoryStream();
        return FromStream(type, ms);
    }
}
