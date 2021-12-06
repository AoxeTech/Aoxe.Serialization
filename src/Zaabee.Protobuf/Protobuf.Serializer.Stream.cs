namespace Zaabee.Protobuf;

public static partial class ProtobufSerializer
{
    private static readonly Lazy<RuntimeTypeModel> Model = new Lazy<RuntimeTypeModel>(() =>
    {
        var typeModel = RuntimeTypeModel.Create();
        typeModel.UseImplicitZeroDefaults = false;
        return typeModel;
    });

    private static RuntimeTypeModel TypeModel => Model.Value;

    /// <summary>
    /// Serialize the generic object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serialize the object to a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Stream Pack(object? value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serialize the generic object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(object? value, Stream? stream)
    {
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserialize the stream to a generic object.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream)
    {
        var result = TypeModel.Deserialize<TValue>(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserialize the stream to an object.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream)
    {
        var result = TypeModel.Deserialize(stream, null, type);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}