namespace Zaabee.Serializer.Abstractions;

public partial interface IJsonSerializer
{
    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToJson<TValue>(TValue? value);
    
    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToJson(Type type, object? value);
}