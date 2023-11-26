namespace Zaabee.Serializer.Abstractions;

public partial interface ITextSerializer
{
    /// <summary>
    /// Serialize to text.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToText<TValue>(TValue? value);

    /// <summary>
    /// Serialize to text.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToText(Type type, object? value);
}
