namespace Aoxe.SharpYaml;

public static partial class SharpYamlHelper
{
    /// <summary>
    /// Convert the provided value to yaml text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value)
    {
        var ms = new MemoryStream();
        new global::SharpYaml.Serialization.Serializer().Serialize(ms, value, typeof(TValue));
        ms.Seek(0, SeekOrigin.Begin);
        return ms;
    }

    /// <summary>
    /// Convert the provided value to yaml text and write it to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value)
    {
        var ms = new MemoryStream();
        new global::SharpYaml.Serialization.Serializer().Serialize(ms, value, type);
        ms.Seek(0, SeekOrigin.Begin);
        return ms;
    }
}
