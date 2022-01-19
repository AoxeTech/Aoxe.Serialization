namespace Zaabee.SharpYaml;

public static partial class SharpYamlHelper
{
    public static TValue? FromStream<TValue>(Stream? stream)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        return new global::SharpYaml.Serialization.Serializer().Deserialize<TValue>(stream);
    }

    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        return new global::SharpYaml.Serialization.Serializer().Deserialize(stream, type);
    }
}