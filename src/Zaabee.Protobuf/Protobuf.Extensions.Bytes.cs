namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static T FromBytes<T>(this byte[] bytes) => ProtobufHelper.Deserialize<T>(bytes);

    public static object FromBytes(this byte[] bytes, Type type) => ProtobufHelper.Deserialize(type, bytes);
}