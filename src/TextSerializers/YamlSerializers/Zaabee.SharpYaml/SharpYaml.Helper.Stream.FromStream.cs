namespace Zaabee.SharpYaml;

public static partial class SharpYamlHelper
{
    public static TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : new global::SharpYaml.Serialization.Serializer().Deserialize<TValue>(stream);

    public static object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : new global::SharpYaml.Serialization.Serializer().Deserialize(stream, type);
}