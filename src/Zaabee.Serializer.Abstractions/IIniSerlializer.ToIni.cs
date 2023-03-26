namespace Zaabee.Serializer.Abstractions;

public partial interface IIniSerializer
{
}

public static partial class IniSerializerExtension
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
}