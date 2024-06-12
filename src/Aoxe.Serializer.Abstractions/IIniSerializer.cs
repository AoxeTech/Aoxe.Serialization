namespace Aoxe.Serializer.Abstractions;

public interface IIniSerializer : ITextSerializer { }

public static class IniSerializerExtension
{
    /// <summary>
    /// Serialize to ini.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToIni<TValue>(this IIniSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to ini.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToIni(this IIniSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);

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
