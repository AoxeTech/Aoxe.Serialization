namespace Aoxe.SharpYaml;

public static partial class SharpYamlExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        SharpYamlHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        SharpYamlHelper.FromStream(type, stream);
}
