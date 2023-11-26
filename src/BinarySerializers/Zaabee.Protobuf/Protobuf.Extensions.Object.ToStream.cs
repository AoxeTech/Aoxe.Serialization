namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) =>
        ProtobufHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value) => ProtobufHelper.ToStream(value);
}
