namespace Zaabee.Protobuf;

public static partial class ProtobufExtensions
{
    public static Stream ToStream<TValue>(this TValue? value) =>
        ProtobufHelper.ToStream(value);

    public static Stream ToStream(this object? value) =>
        ProtobufHelper.ToStream(value);
}