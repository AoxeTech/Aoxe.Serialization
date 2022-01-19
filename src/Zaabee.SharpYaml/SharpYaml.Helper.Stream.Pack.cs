namespace Zaabee.SharpYaml;

public static partial class SharpYamlHelper
{
    /// <summary>
    /// Serialize the value to yaml text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null) return;
        new global::SharpYaml.Serialization.Serializer().Serialize(stream, value, typeof(TValue));
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the value to yaml text and write it to the <see cref="System.IO.Stream"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (stream is null) return;
        new global::SharpYaml.Serialization.Serializer().Serialize(stream, value, type);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}