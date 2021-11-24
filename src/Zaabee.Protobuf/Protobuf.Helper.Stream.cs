namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    public static MemoryStream Pack<T>(T t) =>
        t is null
            ? new MemoryStream()
            : ProtobufSerializer.Pack(t);

    public static MemoryStream Pack(object obj) =>
        obj is null
            ? new MemoryStream()
            : ProtobufSerializer.Pack(obj);

    public static void Pack<T>(T t, Stream stream)
    {
        if (t is not null && stream is not null)
            ProtobufSerializer.Pack(t, stream);
    }

    public static void Pack(object obj, Stream stream)
    {
        if (obj is not null && stream is not null)
            ProtobufSerializer.Pack(obj, stream);
    }

    public static T Unpack<T>(Stream stream) =>
        stream.IsNullOrEmpty()
            ? (T) typeof(T).GetDefaultValue()
            : ProtobufSerializer.Unpack<T>(stream);

    public static object Unpack(Type type, Stream stream) =>
        stream.IsNullOrEmpty()
            ? type.GetDefaultValue()
            : ProtobufSerializer.Unpack(type, stream);
}