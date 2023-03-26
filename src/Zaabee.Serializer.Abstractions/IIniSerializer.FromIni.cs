namespace Zaabee.Serializer.Abstractions;

public partial interface IIniSerializer : ITextSerializer
{
}

public static partial class IniSerializerExtension
{
    /// <summary>
    /// If the ini is null or white space will return the default value of T.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="ini"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromIni<TValue>(this IIniSerializer serializer, string? ini) =>
        serializer.FromText<TValue>(ini);

    /// <summary>
    /// If the ini is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="ini"></param>
    /// <returns></returns>
    public static object? FromIni(this IIniSerializer serializer, Type type, string? ini) =>
        serializer.FromText(type, ini);
}